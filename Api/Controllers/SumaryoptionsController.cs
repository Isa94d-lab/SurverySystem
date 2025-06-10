
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Sumaryoptions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SumaryoptionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SumaryoptionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SumaryoptionsDTO>>> Get()
        {
            var list = await _unitOfWork.Sumaryoptions.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<SumaryoptionsDTO>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SumaryoptionsDTO>> Get(int id)
        {
            var entity = await _unitOfWork.Sumaryoptions.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(_mapper.Map<SumaryoptionsDTO>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<SumaryoptionsDTO>> Create([FromBody] CreateSumaryoptionsDTO dto)
        {
            var entity = _mapper.Map<Sumaryoptions>(dto);
            _unitOfWork.Sumaryoptions.Add(entity);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, _mapper.Map<SumaryoptionsDTO>(entity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Sumaryoptions entity)
        {
            if (id != entity.Id) return BadRequest();
            _unitOfWork.Sumaryoptions.Update(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Sumaryoptions.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Sumaryoptions.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}