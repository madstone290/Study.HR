﻿using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Infrastructure.Data.Repos
{
    public class CareerTypeRepository : Repository<CareerType>, ICareerTypeRepository, ICareerTypeReadRepository
    {
        public CareerTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> ExistCodeAsync(string code)
        {
            return Set.AnyAsync(x=> x.Code == code);
        }

        public Task<bool> ExistNameAsync(string name)
        {
            return Set.AnyAsync(x => x.Name == name);
        }

        public async Task<List<CareerTypeDto>> GetListAsync()
        {
            return await Set.Select(x => new CareerTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            }).ToListAsync();
        }
    }
}
