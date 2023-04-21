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

            builder.HasOne(x => x.PayProfile).WithOne(x => x.Employee)
                .HasForeignKey<PayProfile>(x => x.EmployeeId);

            builder.HasOne(x => x.JobPosition).WithMany()
                .HasForeignKey(x => x.JobPositionId);

            builder.HasOne(x => x.JobRole).WithMany()
                .HasForeignKey(x => x.JobRoleId);

            builder.HasOne(x => x.CareerType).WithMany()
                .HasForeignKey(x => x.CareerTypeId);

            builder.HasOne(x => x.EmploymentType).WithMany()
                .HasForeignKey(x => x.EmploymentTypeId);
        }
    }
}
