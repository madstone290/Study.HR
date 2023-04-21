using Microsoft.AspNetCore.Mvc;
using MediatR;
using Study.HR.Core.Application.Quries.CareerTypeQueries;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Commands.CareerTypeCommands;
using Study.HR.Controllers.Parameters;

namespace Study.HR.Controllers
{
    public class CareerTypeController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CareerTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 전체 경력타입을 조회한다
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<CareerTypeDto>), StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var query = new GetCareerTypesQuery();
            List<CareerTypeDto> careerTypes= await _mediator.Send(query);
            return Ok(careerTypes);
        }


        /// <summary>
        /// 경력타입을 생성한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK, "application/json")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CareerTypeParam careerType)
        {
            var command = new CreateCareerTypeCommand()
            {
                Code = careerType.Code,
                Name = careerType.Name
            };
            int id = await _mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// 경력타입을 수정한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] CareerTypeParam careerType)
        {
            var command = new UpdateCareerTypeCommand()
            {
                Id = id,
                Code = careerType.Code,
                Name = careerType.Name
            };
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// 경력타입을 삭제한다.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var command = new DeleteCareerTypeCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok();
        }


    }
}
