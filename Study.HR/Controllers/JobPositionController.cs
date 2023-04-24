using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Parameters;
using Study.HR.Core.Application.Commands.JobPositionCommands;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Quries;

namespace Study.HR.Controllers
{
    public class JobPositionController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public JobPositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 전체 직위타입을 조회한다
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<JobPositionDto>), StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var query = new GetJobPositionsQuery();
            List<JobPositionDto> JobPositions = await _mediator.Send(query);
            return Ok(JobPositions);
        }


        /// <summary>
        /// 직위를 생성한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, "application/json")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] JobPositionParam JobPosition)
        {
            var command = new CreateJobPositionCommand()
            {
                Code = JobPosition.Code,
                Name = JobPosition.Name
            };
            int id = await _mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// 직위를 수정한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] JobPositionParam JobPosition)
        {
            var command = new UpdateJobPositionCommand()
            {
                Id = id,
                Code = JobPosition.Code,
                Name = JobPosition.Name
            };
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// 직위를 삭제한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var command = new DeleteJobPositionCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }


    }
}
