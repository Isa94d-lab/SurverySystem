using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Categories_catalog;

using Microsoft.EntityFrameworkCore;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Categories_catalogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Categories_catalogController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Categories_catalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories_catalogDTO>>> Get()
        {
            var list = await _unitOfWork.Categories_catalog.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<Categories_catalogDTO>>(list);
            return Ok(listDto);
        }

        // GET: api/Categories_catalog/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories_catalogDTO>> Get(int id)
        {
            var item = await _unitOfWork.Categories_catalog.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<Categories_catalogDTO>(item));
        }

        // POST: api/Categories_catalog
        [HttpPost]
        public async Task<ActionResult<Categories_catalogDTO>> Create([FromBody] CreateCategories_catalogDTO createDto)
        {
            var entity = _mapper.Map<Categories_catalog>(createDto);
            _unitOfWork.Categories_catalog.Add(entity);
            await _unitOfWork.SaveAsync();
            var dto = _mapper.Map<Categories_catalogDTO>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, dto);
        }

        // PUT: api/Categories_catalog/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Categories_catalog entity)
        {
            if (id != entity.Id) return BadRequest();
            _unitOfWork.Categories_catalog.Update(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Categories_catalog/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Categories_catalog.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Categories_catalog.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
