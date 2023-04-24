using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Parameters;
using Study.HR.Core.Application.Commands.JobRoleCmds;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Quries;

namespace Study.HR.Controllers
{
    public class JobRoleController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public JobRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 전체 직무를 조회한다
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<JobRoleDto>), StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var query = new GetJobRolesQuery();
            List<JobRoleDto> JobRoles = await _mediator.Send(query);
            return Ok(JobRoles);
        }


        /// <summary>
        /// 직무를 생성한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, "application/json")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] JobRoleParam JobRole)
        {
            var command = new CreateJobRoleCommand()
            {
                Code = JobRole.Code,
                Name = JobRole.Name
            };
            int id = await _mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// 직무를 수정한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] JobRoleParam JobRole)
        {
            var command = new UpdateJobRoleCommand()
            {
                Id = id,
                Code = JobRole.Code,
                Name = JobRole.Name
            };
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// 직무를 삭제한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var command = new DeleteJobRoleCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }


    }
}
