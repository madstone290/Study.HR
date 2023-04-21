using Study.HR.Core.Application.Base;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;

namespace Study.HR.Core.Application.Quries.DepartmentQueries
{
    public class GetDepartmentsQuery : IQuery<List<DepartmentDto>>
    {
    }

    public class GetDepartmentsQueryHandler : QueryHandler<GetDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IDepartmentReadRepository _repository;

        public GetDepartmentsQueryHandler(IDepartmentReadRepository repository)
        {
            _repository = repository;
        }

        public override Task<List<DepartmentDto>> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
        {
            return _repository.GetListAsync();
        }
    }
}
