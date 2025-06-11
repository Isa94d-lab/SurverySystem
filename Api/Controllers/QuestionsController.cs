using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Questions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionsDTO>>> Get()
        {
            var list = await _unitOfWork.Questions.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<QuestionsDTO>>(list);
            return Ok(listDto);
        }

        // GET: api/Questions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionsDTO>> Get(int id)
        {
            var question = await _unitOfWork.Questions.GetByIdAsync(id);
            if (question == null) return NotFound();
            return Ok(_mapper.Map<QuestionsDTO>(question));
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<ActionResult<QuestionsDTO>> Create([FromBody] CreateQuestionsDTO createDto)
        {
            var entity = _mapper.Map<Questions>(createDto);
            _unitOfWork.Questions.Add(entity);
            await _unitOfWork.SaveAsync();

            var dto = _mapper.Map<QuestionsDTO>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, dto);
        }

        // PUT: api/Questions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Questions question)
        {
            if (id != question.Id) return BadRequest();
            _unitOfWork.Questions.Update(question);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Questions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Questions.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Questions.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
