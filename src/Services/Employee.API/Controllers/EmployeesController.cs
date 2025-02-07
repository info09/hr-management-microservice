using Employee.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Employees.Contact;
using Shared.Dtos.Employees.Employee;
using Shared.Dtos.Employees.EmployeeHistory;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IEmployeeHistoryRepository _employeeHistoryRepository;

        public EmployeesController(IEmployeeRepository employeeRepository, IContactRepository contactRepository, IEmployeeHistoryRepository employeeHistoryRepository)
        {
            _employeeRepository = employeeRepository;
            _contactRepository = contactRepository;
            _employeeHistoryRepository = employeeHistoryRepository;
        }

        #region CRUD

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

        #endregion

        [HttpPost("add-contact")]
        public async Task<IActionResult> AddContact([FromBody]CreateContactDto dto)
        {
            var data = await _contactRepository.AddContact(dto);
            return Ok(data);
        }

        [HttpPost("add-history")]
        public async Task<IActionResult> AddHistory([FromBody] CreateEmployeeHistoryDto dto)
        {
            var data = await _employeeHistoryRepository.AddHistory(dto);
            return Ok(data);
        }
    }
}
