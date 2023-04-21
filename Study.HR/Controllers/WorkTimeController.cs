using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Dtos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Study.HR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkTimeController : ControllerBase
    {
        private readonly Repository<WorkTime> _repository;

        public WorkTimeController(Repository<WorkTime> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] int? employeeId = null)
        {
            var list = await _repository.Set
                .Include(x => x.Employee)
                .ToListAsync();

            return Ok(list);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var emp = await _repository.FindAsync(id);

            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] WorkTime dto)
        {
            WorkTime workTime = new WorkTime()
            {
                //EmployeeId = dto.EmployeeId,
                //MinutesWorked = dto.MinutesWorked,
                //Month = dto.Month,
            };

            await _repository.AddAsync(workTime);

            return Ok(workTime.Id);
        }

    }
}
