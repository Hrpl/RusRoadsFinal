using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RusRoads.Application.Services;
using RusRoads.Domen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RusRoads.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeController;

        
        public EmployeeController(EmployeeService employeeController) 
        { 
            _employeeController = employeeController;
        }


        [Authorize]
        // GET: api/<EmployeeController>/Auth
        [Authorize]
        [HttpGet("Auth")]
        public async Task<ActionResult<Employee>> Get(string login, string password)
        {
            var employee = await _employeeController.Auth(login, password);
            if (employee != null) return Ok(employee);
            else return BadRequest(employee);
        }


        [Authorize]
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
