using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SurveysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surveys>>> Get()
        {
            var list = await _unitOfWork.Surveys.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Surveys>> Get(int id)
        {
            var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
            if (survey == null) return NotFound();
            return Ok(survey);
        }

        [HttpPost]
        public async Task<ActionResult<Surveys>> Create([FromBody] Surveys survey)
        {
            _unitOfWork.Surveys.Add(survey);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = survey.Id }, survey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Surveys survey)
        {
            if (id != survey.Id) return BadRequest();
            _unitOfWork.Surveys.Update(survey);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Surveys.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Surveys.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
