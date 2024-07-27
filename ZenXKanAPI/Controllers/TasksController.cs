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
        return Ok(await context.Tasks.Include(t => t.Tags)
            .Select(t => new TaskItemDto(t.Id, t.ParentId, t.Title,
                t.Tags.Select(tt => new TagItemDto(tt.Id, tt.Name, tt.Color))))
            .ToListAsync());
    }

    // GET api/tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItemDto>> Get(Guid id)
    {
        var task = await context.Tasks.FindAsync(id);


        if (task == null) return NotFound();

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title));
    }


    // POST api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskItemDto>> Post([FromBody] TaskCreateDto taskCreateDto)
    {
        var newTask = new Models.Task(
            taskCreateDto.ParentId,
            taskCreateDto.Title
        );

        if (taskCreateDto.TagIds != null)
            newTask.TaskTags = taskCreateDto.TagIds
                .Select(tagId => new Models.TaskTag { TagId = tagId, TaskId = newTask.Id })
                .ToList();


        context.Tasks.Add(newTask);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = newTask.Id },
            new TaskItemDto(newTask.Id, newTask.ParentId, newTask.Title));
    }

    // PUT api/tasks/5
    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItemDto>> Put(Guid id, [FromBody] TaskUpdateDto taskUpdateDto)
    {
        var task = await context.Tasks.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);

        if (task == null) return NotFound();

        task.Title = taskUpdateDto.Title;
        task.ParentId = taskUpdateDto.ParentId;

        var newTags = taskUpdateDto.TagIds ?? [];
        var currentTags = task.Tags.Select(t => t.Id).ToList();

        foreach (var tagId in currentTags.Except(newTags).ToList())
            task.Tags.Remove(task.Tags.First(t => t.Id == tagId));

        foreach (var tagId in newTags.Except(currentTags).ToList())
        {
            var softDeletedTags = await context.TaskTags
                .IgnoreQueryFilters().Where(tt => tt.TaskId == task.Id && tt.TagId == tagId && tt.DeletedAt != null)
                .ToListAsync();

            if (softDeletedTags.Count == 0)
                task.TaskTags.Add(new Models.TaskTag { TagId = tagId, TaskId = task.Id });
            else
                softDeletedTags.ForEach(t => t.DeletedAt = null);
        }

        await context.SaveChangesAsync();

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title,
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

        return Ok(new TaskItemDto(task.Id, task.ParentId, task.Title));
    }
}