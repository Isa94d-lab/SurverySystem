using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities; 
using Infrastructure.Data; // O el namespace donde tienes AppDbContext
using Application.Interfaces; // O el namespace donde está IUnitOfWork
using Microsoft.EntityFrameworkCore;


namespace Api.Controllers
{
    public class Category_optionsController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public Category_optionsController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Category_options>>> Get()
        {
            var categories_catalog = await _context.Category_options
                            .ToListAsync();
            return Ok(categories_catalog);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var category_options = await _context.Category_options.FindAsync(id);
            return Ok(category_options);
        }
            
            
        }
}