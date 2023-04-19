using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IDbContextTransaction BeginTransaction();
    }
}
