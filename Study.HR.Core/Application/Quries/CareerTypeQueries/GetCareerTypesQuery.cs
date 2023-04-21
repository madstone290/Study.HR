using Study.HR.Core.Application.Base;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;

namespace Study.HR.Core.Application.Quries.CareerTypeQueries
{
    public class GetCareerTypesQuery : IQuery<List<CareerTypeDto>>
    { 
    }

    public class GetCareerTypesQueryHandler : IQueryHandler<GetCareerTypesQuery, List<CareerTypeDto>>
    {
        private readonly ICareerTypeReadRepository _repository;

        public GetCareerTypesQueryHandler(ICareerTypeReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CareerTypeDto>> Handle(GetCareerTypesQuery request, CancellationToken cancellationToken)
        {
             return await _repository.GetListAsync();
        }
    }
}
