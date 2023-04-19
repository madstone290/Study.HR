using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Dtos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Infrastructure.Data;

namespace Study.HR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly Repository<EmployeeSalary> _repository;
        private readonly IEmployeeSalaryReadRepository _employeeSalaryReadRepository;

        public EmployeeSalaryController(ILogger<EmployeeController> logger, 
            Repository<EmployeeSalary> repository,
            IEmployeeSalaryReadRepository employeeSalaryReadRepository)
        {
            _logger = logger;
            _repository = repository;
            _employeeSalaryReadRepository = employeeSalaryReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] int? employeeId = null)
        {
            dynamic list;
            if(employeeId.HasValue)
                list = await _employeeSalaryReadRepository.GetListAsync(employeeId.Value);
            else
                list = await _employeeSalaryReadRepository.GetListAsync();
            return Ok(list);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var emp = await _employeeSalaryReadRepository.GetAsync(id);

            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeSalaryDto dto)
        {
            EmployeeSalary salary = new EmployeeSalary()
            {
                EmployeeId = dto.EmployeeId,
                BaseSalary = dto.BaseSalary,
                BonusRate = dto.BonusRate,
                ValidAfter = dto.ValidAfter,
                ValidBefore = dto.ValidBefore
            };

            await _repository.AddAsync(salary);

            return Ok(salary.Id);
        }

    }
}
