using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenXKanAPI.Dtos;
using ZenXKanCore.Data;
using Models = ZenXKanCore.Models;

namespace ZenXKanAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly ZenXKanContext _context;

    public ProjectsController(ZenXKanContext context)
    {
        _context = context;
    }


    // GET: api/v1/projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectItemDto>>> GetAll()
    {
        return await _context.Projects.Select(p => new ProjectItemDto(p.Id, p.Title)).ToListAsync();
    }

    // GET api/v1/projects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectItemDto>> Get(Ulid id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null) return NotFound();

        return new ProjectItemDto(project.Id, project.Title);
    }

    // POST api/v1/projects
    [HttpPost]
    public async Task<ActionResult<ProjectItemDto>> Post([FromBody] ProjectCreateDto projectCreateDto)
    {
        var newProject = new Models.Project(
            projectCreateDto.Title
        );
        _context.Add(newProject);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(Get), new { id = newProject.Id },
            new ProjectItemDto(newProject.Id, newProject.Title));
    }

    // PUT api/v1/projects/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/v1/projects/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}