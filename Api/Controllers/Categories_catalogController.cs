using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities; 
using Infrastructure.Data; // O el namespace donde tienes AppDbContext
using Application.Interfaces; // O el namespace donde está IUnitOfWork
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;
public class Categories_catalogController :BaseApiController
    {
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    public Categories_catalogController(AppDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Categories_catalog>>> Get()
    {
        var categories_catalog = await _context.Categories_catalog
                        .ToListAsync();
        return Ok(categories_catalog);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var categories_catalog = await _context.Categories_catalog.FindAsync(id);
        return Ok(categories_catalog);
    }
}
