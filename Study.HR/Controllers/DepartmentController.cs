using Microsoft.AspNetCore.Mvc;
using MediatR;
using Study.HR.Core.Application.Quries.DepartmentQueries;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Commands.DepartmentCommands;
using Study.HR.Controllers.Parameters;

namespace Study.HR.Controllers
{
    public class DepartmentController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 전체 부서를 조회한다
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<DepartmentDto>), StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var query = new GetDepartmentsQuery();
            List<DepartmentDto> Departments= await _mediator.Send(query);
            return Ok(Departments);
        }


        /// <summary>
        /// 부서를 생성한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, "application/json")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentParam department)
        {
            var command = new CreateDepartmentCommand()
            {
                Code = department.Code,
                Name = department.Name,
                UpperDepartmentId = department.UpperDepartmentId
            };
            int id = await _mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// 부서를 수정한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] DepartmentParam department)
        {
            var command = new UpdateDepartmentCommand()
            {
                Id = id,
                Code = department.Code,
                Name = department.Name,
                UpperDepartmentId = department.UpperDepartmentId
            };
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// 부서를 삭제한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var command = new DeleteDepartmentCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }


    }
}
