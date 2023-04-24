using Study.HR.Core.Application.Base;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;

namespace Study.HR.Core.Application.Quries
{
    public class GetEmployeesQuery : IQuery<List<EmployeeDto>>
    {
    }

    public class GetEmployeesQueryHandler : QueryHandler<GetEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeReadRepository _repository;

        public GetEmployeesQueryHandler(IEmployeeReadRepository repository)
        {
            _repository = repository;
        }

        public override Task<List<EmployeeDto>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            return _repository.GetListAsync();
        }
    }
}
