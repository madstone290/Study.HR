using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Dtos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Domain.Repos;
using Dapper;
using System.Collections.Generic;

namespace Study.HR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryRecordController : ControllerBase
    {
        private readonly Repository<Payroll> _repository;

        public SalaryRecordController(Repository<Payroll> repository)
        {
            _repository = repository;
        }

        public class Test
        {
            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public int MinutesWorked { get; set; }

        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] int? employeeId = null)
        {
            var list = _repository.Context.Set<WorkTime>().Include(x=> x.Employee).Select(x => new
            object[]
            {
                x.Employee.Name,
                x.MinutesWorked,
                null,
                x.Month
            }).ToList();

            var table = new
            {
                Columns = new List<string>()
                {
                    "이름", "시간(분)", "보너스", "월"
                },
                Rows = list
            };
            

            return Ok(table);
            //            List<List<dynamic>> list = new List<List<dynamic>>();
            //            using (var connection = _repository.Context.Database.GetDbConnection())
            //            {
            //                var reader = await connection.ExecuteReaderAsync(@"
            //select e.Id, e.Name, w.MinutesWorked from
            //employee e 
            //join worktime w on 
            //e.Id = w.EmployeeId");




            //                while (reader.Read())
            //                {
            //                    var inList = new List<dynamic>();

            //                    for(int i = 0; i < reader.FieldCount; i++)
            //                    {
            //                        inList.Add(reader.GetValue(i));
            //                    }

            //                    list.Add(inList);
            //                }

            //                //var list = await connection.QueryAsync(@"select Id, Name from employee");


            //                return Ok(list);
        //}


            //var list = await _repository.Entities
            //    .Include(x => x.Employee)
            //    .Include(x => x.WorkTime)
            //    .Include(x => x.EmployeeSalary)
            //    .ToListAsync();

            //return Ok(list);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var emp = await _repository.GetAsync(id);

            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Payroll dto)
        {
            Payroll workTime = new Payroll()
            {
              
            };

            await _repository.AddAsync(workTime);

            return Ok(workTime.Id);
        }

    }
}
