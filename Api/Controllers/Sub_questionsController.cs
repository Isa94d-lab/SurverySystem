using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Sub_questions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Sub_questionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Sub_questionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sub_questionsDTO>>> Get()
        {
            var list = await _unitOfWork.Sub_questions.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Sub_questionsDTO>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sub_questionsDTO>> Get(int id)
        {
            var item = await _unitOfWork.Sub_questions.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<Sub_questionsDTO>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Sub_questionsDTO>> Create([FromBody] CreateSub_questionsDTO dto)
        {
            var entity = _mapper.Map<Sub_questions>(dto);
            _unitOfWork.Sub_questions.Add(entity);
            await _unitOfWork.SaveAsync();
            var result = _mapper.Map<Sub_questionsDTO>(entity);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Sub_questions entity)
        {
            if (id != entity.Id) return BadRequest();
            _unitOfWork.Sub_questions.Update(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Sub_questions.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Sub_questions.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
