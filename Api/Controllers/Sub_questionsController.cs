using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Sub_questionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public Sub_questionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sub_questions>>> Get()
        {
            var list = await _unitOfWork.Sub_questions.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sub_questions>> Get(int id)
        {
            var item = await _unitOfWork.Sub_questions.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Sub_questions>> Create([FromBody] Sub_questions entity)
        {
            _unitOfWork.Sub_questions.Add(entity);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
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
