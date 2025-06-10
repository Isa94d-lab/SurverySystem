using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Options_response;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Options_responseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Options_responseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Options_response
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Options_responseDTO>>> Get()
        {
            var list = await _unitOfWork.Options_response.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<Options_responseDTO>>(list);
            return Ok(listDto);
        }

        // GET: api/Options_response/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Options_responseDTO>> Get(int id)
        {
            var item = await _unitOfWork.Options_response.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<Options_responseDTO>(item));
        }

        // POST: api/Options_response
        [HttpPost]
        public async Task<ActionResult<Options_responseDTO>> Create([FromBody] CreateOptions_responseDTO createDto)
        {
            var entity = _mapper.Map<Options_response>(createDto);
            _unitOfWork.Options_response.Add(entity);
            await _unitOfWork.SaveAsync();
            var dto = _mapper.Map<Options_responseDTO>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, dto);
        }

        // PUT: api/Options_response/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Options_response entity)
        {
            if (id != entity.Id) return BadRequest();
            _unitOfWork.Options_response.Update(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Options_response/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Options_response.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _unitOfWork.Options_response.Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
