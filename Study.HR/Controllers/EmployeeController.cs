using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

      

    }
}
