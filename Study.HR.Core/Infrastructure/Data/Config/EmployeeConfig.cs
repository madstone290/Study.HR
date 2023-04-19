using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.EnteredDate).IsRequired();
            builder.HasOne(x => x.Detail).WithOne(x=> x.Employee)
                .HasForeignKey<EmployeeDetail>(x=> x.EmployeeId);
        }
    }
}
