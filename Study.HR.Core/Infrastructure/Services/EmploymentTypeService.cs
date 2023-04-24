﻿using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Infrastructure.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IEmploymentTypeRepository _repository;

        public EmploymentTypeService(IEmploymentTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CodeExistAsync(string code)
        {
            return _repository.ExistCodeAsync(code);
        }

        public Task<bool> NameExistAsync(string name)
        {
            return _repository.ExistNameAsync(name);
        }
    }
}
