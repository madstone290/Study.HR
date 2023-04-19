using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class EmployeeDetailConfig : IEntityTypeConfiguration<EmployeeDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeeDetail> builder)
        {
        }
    }
}
