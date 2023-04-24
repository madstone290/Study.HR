﻿using Study.HR.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Repos
{
    public interface IJobPositionRepository : IRepository<JobPosition>
    {
        Task<bool> ExistCodeAsync(string code);
        Task<bool> ExistNameAsync(string name);
    }
}
