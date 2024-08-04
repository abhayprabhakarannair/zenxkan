using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenXKanAPI.Dtos;
using ZenXKanCore.Data;
using Models = ZenXKanCore.Models;

namespace ZenXKanAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TasksController(ZenXKanContext context) : ControllerBase
{
    // GET: api/tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll()
    {
        return Ok(await context.Tasks
            .OrderBy(t => t.ViewOrderId)
            .Include(t => t.Tags)
            .Select(t =>
                new TaskItemDto(
                    t.Id,
                    t.ParentId,
                    t.Title,
                    t.Description,
                    t.ViewOrderId,
                    t.CompletedAt,
                    t.Tags.Select(tt => new TagItemDto(tt.Id, tt.Name, tt.Color)))
            )
            .ToListAsync());
    }

    // GET api/tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItemDto>> Get(Guid id)
    {
        var task = await context.Tasks.FindAsync(id);


        if (task == null) return NotFound();

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title, task.Description, task.ViewOrderId,
            task.CompletedAt));
    }


    // POST api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskItemDto>> Post([FromBody] TaskCreateDto taskCreateDto)
    {
        var newTask = new Models.Task(
            taskCreateDto.ParentId,
            taskCreateDto.Title,
            taskCreateDto.Description
        );

        if (taskCreateDto.TagIds != null)
            newTask.TaskTags = taskCreateDto.TagIds
                .Select(tagId => new Models.TaskTag { TagId = tagId, TaskId = newTask.Id })
                .ToList();

        newTask.ViewOrderId = await _generateViewOrderIdForNewTask();

        context.Tasks.Add(newTask);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = newTask.Id },
            new TaskItemDto(newTask.Id, newTask.ParentId, newTask.Title, newTask.Description, newTask.ViewOrderId,
                null));
    }

    // PUT api/tasks/5
    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItemDto>> Put(Guid id, [FromBody] TaskUpdateDto taskUpdateDto)
    {
        var task = await context.Tasks.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);

        if (task == null) return NotFound();

        task.Title = taskUpdateDto.Title;
        task.ParentId = taskUpdateDto.ParentId;

        task.TaskTags.Clear();
        foreach (var tagId in taskUpdateDto.TagIds ?? [])
            task.TaskTags.Add(new Models.TaskTag { TagId = tagId, TaskId = task.Id });

        await context.SaveChangesAsync();

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title, task.Description, task.ViewOrderId,
            task.CompletedAt,
            task.Tags.Select(t => new TagItemDto(t.Id, t.Name, t.Color))));
    }


    // PUT api/tasks/5/complete
    [HttpPatch("{id}/complete")]
    public async Task<ActionResult<TaskItemDto>> Completed(Guid id)
    {
        var task = await context.Tasks.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);

        if (task == null) return NotFound();

        task.CompletedAt = DateTime.Now;

        await context.SaveChangesAsync();

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title, task.Description, task.ViewOrderId,
            task.CompletedAt,
            task.Tags.Select(t => new TagItemDto(t.Id, t.Name, t.Color))));
    }

    // DELETE api/tasks/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskItemDto>> Delete(Guid id)
    {
        var task = await context.Tasks.FindAsync(id);

        if (task == null) return NotFound();

        context.Remove(task);
        await context.SaveChangesAsync();

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title, task.Description, task.ViewOrderId,
            task.CompletedAt));
    }


    private async Task<double> _generateViewOrderIdForNewTask()
    {
        var minViewOrderId = await context.Tasks.MinAsync(t => t.ViewOrderId);
        return minViewOrderId / 2;
    }
}