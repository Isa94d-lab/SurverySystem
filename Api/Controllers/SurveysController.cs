using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Surveys;
// New
using Microsoft.AspNetCore.RateLimiting;
// ---


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // New
    [EnableRateLimiting("token")]
    // ----
    public class SurveysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public SurveysController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // ALterado por DOTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveysDTO>>> Get()
        {
            var list = await _unitOfWork.Surveys.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<SurveysDTO>>(list); // ⬅ Convierte entidades -> DTOs
            return Ok(listDto);
        }

        // Alterado por DOTs
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveysDTO>> Get(int id)
        {
            var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
            if (survey == null) return NotFound();
            return Ok(_mapper.Map<SurveysDTO>(survey)); // ⬅ Convierte entidad -> DTO
        }


        // ESta parte del codigo se altero al momento de agregar los DOTs
        [HttpPost]
        public async Task<ActionResult<SurveysDTO>> Create([FromBody] CreateSurveysDTO createSurveyDto)
        {
            var survey = _mapper.Map<Surveys>(createSurveyDto); // ⬅ Convierte DTO -> entidad
            _unitOfWork.Surveys.Add(survey);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = survey.Id }, _mapper.Map<SurveysDTO>(survey)); // ⬅ Devuelve DTO
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
