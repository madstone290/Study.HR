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
        private readonly Repository<PayProfile> _repository;
        private readonly IPayProfileReadRepository _employeeSalaryReadRepository;

        public EmployeeSalaryController(ILogger<EmployeeController> logger, 
            Repository<PayProfile> repository,
            IPayProfileReadRepository employeeSalaryReadRepository)
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
            PayProfile salary = new PayProfile()
            {
                
            };

            await _repository.AddAsync(salary);

            return Ok(salary.Id);
        }

    }
}
