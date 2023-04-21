using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.HR.Controllers.Dtos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Infrastructure.Data;

namespace Study.HR.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly Repository<Employee> _repository;

        public EmployeeController(ILogger<EmployeeController> logger, Repository<Employee> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] string? name)
        {
           List<Employee> employees;
            if (name == null)
                employees = await _repository.Context.Set<Employee>().ToListAsync();
            else
                employees = await _repository.GetListAsync(x => x.Name.Contains(name));
            return Ok(employees.Select(x => new EmployeeDto()
            {
                Id = x.Id,
                Name = x.Name,
                //SalaryType = x.SalaryType,
                //Address = x.Address,
                //LoginId = x.LoginId,
                //LoginPassword = x.LoginPassword,
                //Email = x.Email,
                //EnteredDate = x.EnteredDate,
                //DateOfBirth = x.DateOfBirth,
                //BaseSalary = x.BaseSalary,
                //SalaryCurrency = x.SalaryCurrency,
                //PhoneNumber = x.PhoneNumber,
                //Desc = x.Detail?.Desc,
                //Rate = x.Detail?.Rate ?? 0,
            }).ToList());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var emp = await _repository.GetAsync(id);
            if (emp == null)
                return Ok(null);

            return Ok(new EmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                //SalaryType = emp.SalaryType,
                //Address = emp.Address,
                //LoginId = emp.LoginId,
                //LoginPassword = emp.LoginPassword,
                //Email = emp.Email,
                //EnteredDate = emp.EnteredDate,
                //DateOfBirth = emp.DateOfBirth,
                //BaseSalary = emp.BaseSalary,
                //SalaryCurrency = emp.SalaryCurrency,
                //PhoneNumber = emp.PhoneNumber,
                //Desc = emp.Detail?.Desc,
                //Rate = emp.Detail?.Rate ?? 0,
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeDto employeeDto)
        {
            Employee employee = new Employee()
            {
                //Address = employeeDto.Address,
                //LoginId = employeeDto.LoginId,
                //SalaryType = employeeDto.SalaryType,
                //LoginPassword = employeeDto.LoginPassword,
                //Email = employeeDto.Email,
                //Name = employeeDto.Name,
                //EnteredDate = employeeDto.EnteredDate,
                //DateOfBirth = employeeDto.DateOfBirth,
                //BaseSalary = employeeDto.BaseSalary,
                //SalaryCurrency = employeeDto.SalaryCurrency,
                //PhoneNumber = employeeDto.PhoneNumber,

                //Detail = new EmployeeDetail() { Desc = employeeDto.Desc, Rate = employeeDto.Rate }
            };
            await _repository.AddAsync(employee);
            
            return Ok(employee.Id);
        }

    }
}
