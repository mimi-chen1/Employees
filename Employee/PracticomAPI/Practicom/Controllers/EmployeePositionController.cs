using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practicom.API.Models;
using Practicom.Core.DTOs;
using Practicom.Core.Entites;
using Practicom.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practicom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionController : ControllerBase
    {

        private readonly IEmployeePositionService _employeePositionService;
        private readonly IMapper _mapper;

        public EmployeePositionController(IEmployeePositionService employeePositionService, IMapper mapper)
        {
           _employeePositionService = employeePositionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var EmployeePosition = await _employeePositionService.GetPositionEmployee();
            return Ok(_mapper.Map<IEnumerable<EmployeePositionDto>>(EmployeePosition));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var EmployeePositionById = await _employeePositionService.GetById(id);
            return Ok(_mapper.Map<EmployeePositionDto>(EmployeePositionById));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePositionPostModel employeePosition)
        {
            var EmployeeToAdd = await _employeePositionService.AddPositionEmployee(_mapper.Map<EmployeePosition>(employeePosition));
            return Ok(_mapper.Map<EmployeePositionDto>(EmployeeToAdd));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePositionPostModel employee)
        {
            var EmployeeToUpdate = await _employeePositionService.UpdatePositionEmployee(id, _mapper.Map<EmployeePosition>(employee));
            return Ok(_mapper.Map<EmployeePositionDto>(EmployeeToUpdate));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await  _employeePositionService.DeletePositionEmployee(id);
            return Ok();
        }
    }
}


