using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenXKanAPI.Dtos;
using ZenXKanCore.Data;
using Models = ZenXKanCore.Models;

namespace ZenXKanAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ZenXKanContext _context;


    public TasksController(ZenXKanContext context)
    {
        _context = context;
    }

    // GET: api/tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll()
    {
        return await _context.Tasks.Select(t => new TaskItemDto(t.Id, t.ProjectId, t.ParentId, t.Title)).ToListAsync();
    }

    // GET api/tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItemDto>> Get(Ulid id)
    {
        var task = await _context.Tasks.FindAsync(id);


        if (task == null) return NotFound();

        return new TaskItemDto(task.Id, task.ProjectId, task.ParentId, task.Title);
    }


    // POST api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskItemDto>> Post([FromBody] TaskCreateDto taskCreateDto)
    {
        var newTask = new Models.Task(
            taskCreateDto.ProjectId,
            taskCreateDto.ParentId,
            taskCreateDto.Title
        );
        _context.Tasks.Add(newTask);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = newTask.Id },
            new TaskItemDto(newTask.Id, newTask.ProjectId, newTask.ParentId, newTask.Title));
    }

    // PUT api/tasks/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/tasks/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}