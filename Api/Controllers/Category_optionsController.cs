using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Category_options;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Category_optionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Category_optionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Category_options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category_optionsDTO>>> Get()
        {
            var list = await _unitOfWork.Category_options.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<Category_optionsDTO>>(list);
            return Ok(listDto);
        }

        // GET: api/Category_options/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category_optionsDTO>> Get(int id)
        {
            var item = await _unitOfWork.Category_options.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<Category_optionsDTO>(item));
        }

        // POST: api/Category_options
        [HttpPost]
        public async Task<ActionResult<Category_optionsDTO>> Create([FromBody] CreateCategory_optionsDTO createDto)
        {
            var entity = _mapper.Map<Category_options>(createDto);
            _unitOfWork.Category_options.Add(entity);
            await _unitOfWork.SaveAsync();
            var dto = _mapper.Map<Category_optionsDTO>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, dto);
        }

        // PUT: api/Category_options/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCategory_optionsDTO dto)
        {
            var existing = await _unitOfWork.Category_options.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            _unitOfWork.Category_options.Update(existing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Category_options/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Category_options.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Category_options.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
