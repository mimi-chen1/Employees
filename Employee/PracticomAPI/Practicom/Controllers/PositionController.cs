using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practicom.API.Models;
using Practicom.Core.DTOs;
using Practicom.Core.Entites;
using Practicom.Core.Services;
using System.Net.WebSockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practicom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }
        // GET: api/<PositionController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var listPosition = await _positionService.GetPositions();
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(listPosition));
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var positionById = await _positionService.GetById(id);
            return Ok(_mapper.Map<PositionDto>(positionById));
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] PositionPostModel position)
        {
            var positionToAdd = await _positionService.AddPosition(_mapper.Map<Position>(position));
             return Ok(_mapper.Map<PositionDto>(positionToAdd));
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PositionPostModel p)
        {
             var position=await _positionService.GetById(id);
            if(position == null)
            {
                return NotFound();
            }
            _mapper.Map(p, position);  
            await _positionService.UpdatePosition(position);
           position=await _positionService.GetById(id);
            return Ok(_mapper.Map<PositionDto>(position));
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var position= await _positionService.GetById(id);
            if(position == null)
            {
                return NotFound();
            }
           await _positionService.RemovePosition(id);
            return Ok();
        }
    }
}
