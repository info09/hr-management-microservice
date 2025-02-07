using Employee.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Employee;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _employeeRepository.GetEmployees();
            return Ok(data);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] EmployeeSearchDto search)
        {
            var data = await _employeeRepository.GetAllEmployees(search);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _employeeRepository.GetEmployee(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            var data = await _employeeRepository.CreateEmployee(dto);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto dto)
        {
            var data = await _employeeRepository.UpdateEmployee(dto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var data = await _employeeRepository.DeleteEmployee(id);
            return Ok(data);
        }

    }
}
