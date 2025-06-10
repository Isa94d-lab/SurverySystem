using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questions>>> Get()
        {
            var list = await _unitOfWork.Questions.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Questions>> Get(int id)
        {
            var item = await _unitOfWork.Questions.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Questions>> Create([FromBody] Questions entity)
        {
            _unitOfWork.Questions.Add(entity);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Questions entity)
        {
            if (id != entity.Id) return BadRequest();
            _unitOfWork.Questions.Update(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

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
