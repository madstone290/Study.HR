using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.HR.Controllers.Parameters;
using Study.HR.Core.Application.Commands.EmploymentTypeCmds;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Quries;

namespace Study.HR.Controllers
{
    public class EmploymentTypeController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public EmploymentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 전체 고용타입을 조회한다
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<EmploymentTypeDto>), StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var query = new GetEmploymentTypesQuery();
            List<EmploymentTypeDto> EmploymentTypes = await _mediator.Send(query);
            return Ok(EmploymentTypes);
        }


        /// <summary>
        /// 고용타입을 생성한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, "application/json")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmploymentTypeParam EmploymentType)
        {
            var command = new CreateEmploymentTypeCommand()
            {
                Code = EmploymentType.Code,
                Name = EmploymentType.Name
            };
            int id = await _mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// 고용타입을 수정한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] EmploymentTypeParam EmploymentType)
        {
            var command = new UpdateEmploymentTypeCommand()
            {
                Id = id,
                Code = EmploymentType.Code,
                Name = EmploymentType.Name
            };
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// 고용타입을 삭제한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var command = new DeleteEmploymentTypeCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }


    }
}
