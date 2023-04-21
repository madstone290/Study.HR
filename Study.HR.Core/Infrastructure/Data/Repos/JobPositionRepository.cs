using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Infrastructure.Data.Repos
{
    public class JobPositionRepository : Repository<JobPosition>, IJobPositionRepository
    {
        public JobPositionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
