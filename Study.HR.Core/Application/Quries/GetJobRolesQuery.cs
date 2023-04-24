using Study.HR.Core.Application.Base;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;

namespace Study.HR.Core.Application.Quries
{
    public class GetJobRolesQuery : IQuery<List<JobRoleDto>>
    {
    }

    public class GetJobRolesQueryHandler : QueryHandler<GetJobRolesQuery, List<JobRoleDto>>
    {
        private readonly IJobRoleReadRepository _repository;

        public GetJobRolesQueryHandler(IJobRoleReadRepository repository)
        {
            _repository = repository;
        }

        public override Task<List<JobRoleDto>> Handle(GetJobRolesQuery query, CancellationToken cancellationToken)
        {
            return _repository.GetListAsync();
        }
    }
}
