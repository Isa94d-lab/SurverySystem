using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChaptersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ChaptersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Chapters
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chapters>>> Get()
    {
        var chapters = await _unitOfWork.Chapters.GetAllAsync();
        return Ok(chapters);
    }

    // GET: api/Chapters/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (chapter == null) return NotFound();
        return Ok(chapter);
    }

    // POST: api/Chapters
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Chapters>> Create([FromBody] Chapters chapter)
    {
        _unitOfWork.Chapters.Add(chapter);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = chapter.Id }, chapter);
    }

    // PUT: api/Chapters/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] Chapters chapter)
    {
        if (id != chapter.Id) return BadRequest();

        _unitOfWork.Chapters.Update(chapter);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    // DELETE: api/Chapters/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (existing == null) return NotFound();

        _unitOfWork.Chapters.Remove(existing);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
