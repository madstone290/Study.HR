using Study.HR.Core.Application.Base;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;

namespace Study.HR.Core.Application.Quries
{
    public class GetEmploymentTypesQuery : IQuery<List<EmploymentTypeDto>>
    {
    }

    public class GetEmploymentTypesQueryHandler : QueryHandler<GetEmploymentTypesQuery, List<EmploymentTypeDto>>
    {
        private readonly IEmploymentTypeReadRepository _repository;

        public GetEmploymentTypesQueryHandler(IEmploymentTypeReadRepository repository)
        {
            _repository = repository;
        }

        public override Task<List<EmploymentTypeDto>> Handle(GetEmploymentTypesQuery query, CancellationToken cancellationToken)
        {
            return _repository.GetListAsync();
        }
    }
}
