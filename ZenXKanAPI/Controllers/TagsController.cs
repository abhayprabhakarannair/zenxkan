using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenXKanAPI.Dtos;
using ZenXKanCore.Data;
using Models = ZenXKanCore.Models;

namespace ZenXKanAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ZenXKanContext _context;


    public TagsController(ZenXKanContext context)
    {
        _context = context;
    }

    // GET: api/tags
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagItemDto>>> GetAll()
    {
        return await _context.Tags.Select(t => new TagItemDto(t.Id, t.Name, t.Color)).ToListAsync();
    }

    // GET api/tags/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TagItemDto>> Get(Guid id)
    {
        var tag = await _context.Tags.FindAsync(id);


        if (tag == null) return NotFound();

        return new TagItemDto(tag.Id, tag.Name, tag.Color);
    }


    // POST api/tags
    [HttpPost]
    public async Task<ActionResult<TagItemDto>> Post([FromBody] TagCreateDto tagCreateDto)
    {
        var newTag = new Models.Tag(
            tagCreateDto.Name,
            tagCreateDto.Color
        );
        _context.Tags.Add(newTag);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = newTag.Id },
            new TagItemDto(newTag.Id, newTag.Name, newTag.Color));
    }

    // PUT api/tags/5
    [HttpPut("{id}")]
    public async Task<ActionResult<TagItemDto>> Put(Guid id, [FromBody] string value)
    {
        return NotFound();
    }

    // DELETE api/tags/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<TagItemDto>> Delete(Guid id)
    {
        var tag = await _context.Tags.FindAsync(id);

        if (tag == null) return NotFound();

        _context.Remove(tag);
        await _context.SaveChangesAsync();

        return new TagItemDto(tag.Id, tag.Name, tag.Color);
    }
}