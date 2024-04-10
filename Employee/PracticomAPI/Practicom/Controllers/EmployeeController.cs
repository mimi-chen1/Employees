using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practicom.API.Models;
using Practicom.Core.DTOs;
using Practicom.Core.Entites;
using Practicom.Core.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practicom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService= employeeService;
            _mapper= mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var listEmployee = await _employeeService.GetEmployee();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(listEmployee));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var employeeById = await _employeeService.GetById(id);
            return Ok(_mapper.Map<EmployeeDto>(employeeById));
        }

        // POST api/<EmployeeController>
        [HttpPost]
          public async Task<ActionResult> Post([FromBody] EmployeePostModel model)
        {
            var newEmployee = await _employeeService.AddEmployee(_mapper.Map<Employee>(model));
            return Ok(_mapper.Map<EmployeeDto>(newEmployee));
        }
       
            // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] EmployeePostModel employeePostModel)
        {
            var employee = await _employeeService.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }

            _mapper.Map(employeePostModel, employee);
            await _employeeService.UpdateEmployee(employee);
            employee = await _employeeService.GetById(id);
            return Ok(_mapper.Map<EmployeeDto>(employee));
            
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {
            var employee= await _employeeService.GetById(id);
            if(employee is null)
            {
                return NotFound();
            }
           
           await _employeeService.DeleteEmployee(id);
            return NoContent();
        }

       
    }
}
