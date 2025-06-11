using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Option_questions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Option_questionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Option_questionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option_questionsDTO>>> Get()
        {
            var list = await _unitOfWork.Option_questions.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<Option_questionsDTO>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Option_questionsDTO>> Get(int id)
        {
            var item = await _unitOfWork.Option_questions.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<Option_questionsDTO>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Option_questionsDTO>> Create([FromBody] CreateOption_questionsDTO createDto)
        {
            var entity = _mapper.Map<Option_questions>(createDto);
            _unitOfWork.Option_questions.Add(entity);
            await _unitOfWork.SaveAsync();
            var dto = _mapper.Map<Option_questionsDTO>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateOption_questionsDTO dto)
        {
            var existing = await _unitOfWork.Option_questions.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            _unitOfWork.Option_questions.Update(existing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Option_questions.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _unitOfWork.Option_questions.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
