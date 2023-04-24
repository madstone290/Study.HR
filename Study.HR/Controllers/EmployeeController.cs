using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Parameters;
using Study.HR.Core.Application.Commands.EmployeeCommands;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Quries;

namespace Study.HR.Controllers
{
    public class EmployeeController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 전체 직원을 조회한다
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var query = new GetEmployeesQuery();
            List<EmployeeDto> employees = await _mediator.Send(query);
            return Ok(employees);
        }


        /// <summary>
        /// 직원을 생성한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, "application/json")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeParam emp)
        {
            var command = new CreateEmployeeCommand()
            {
                Code = emp.Code,
                Name = emp.Name,
                ResidentNumber = emp.ResidentNumber,
                HireDate = emp.HireDate,
                RetireDate = emp.RetireDate,
                RetireReason = emp.RetireReason,
                EnglishName = emp.EnglishName,
                IsHouseOwner = emp.IsHouseOwner,
                Memo = emp.Memo,
                ImagePath = emp.ImagePath,
                Password = emp.Password,
                Email = emp.Email,
                MobileNumber = emp.MobileNumber,
                PhoneNumber = emp.PhoneNumber,
                Address = emp.Address,
                ZipCode = emp.ZipCode,
                CareerTypeId = emp.CareerTypeId,
                JobRoleId = emp.JobRoleId,
                EmploymentTypeId = emp.EmploymentTypeId,
                JobPositionId = emp.JobPositionId,
            };
            int id = await _mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// 직원을 수정한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] EmployeeParam emp)
        {
            var command = new UpdateEmployeeCommand()
            {
                Id = id,
                Code = emp.Code,
                Name = emp.Name,
                ResidentNumber = emp.ResidentNumber,
                HireDate = emp.HireDate,
                RetireDate = emp.RetireDate,
                RetireReason = emp.RetireReason,
                EnglishName = emp.EnglishName,
                IsHouseOwner = emp.IsHouseOwner,
                Memo = emp.Memo,
                ImagePath = emp.ImagePath,
                Password = emp.Password,
                Email = emp.Email,
                MobileNumber = emp.MobileNumber,
                PhoneNumber = emp.PhoneNumber,
                Address = emp.Address,
                ZipCode = emp.ZipCode,
                CareerTypeId = emp.CareerTypeId,
                JobRoleId = emp.JobRoleId,
                EmploymentTypeId = emp.EmploymentTypeId,
                JobPositionId = emp.JobPositionId,
            };
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// 직원을 삭제한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var command = new DeleteEmployeeCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }





    }
}
