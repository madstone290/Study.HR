using Study.HR.Core.Application.Base;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;

namespace Study.HR.Core.Application.Quries
{
    public class GetJobPositionsQuery : IQuery<List<JobPositionDto>>
    {
    }

    public class GetJobPositionsQueryHandler : QueryHandler<GetJobPositionsQuery, List<JobPositionDto>>
    {
        private readonly IJobPositionReadRepository _repository;

        public GetJobPositionsQueryHandler(IJobPositionReadRepository repository)
        {
            _repository = repository;
        }

        public override Task<List<JobPositionDto>> Handle(GetJobPositionsQuery query, CancellationToken cancellationToken)
        {
            return _repository.GetListAsync();
        }
    }
}
