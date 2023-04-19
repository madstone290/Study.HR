using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class EmployeeSalaryConfig : IEntityTypeConfiguration<EmployeeSalary>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
        {
            builder.ToTable("EmployeeSalary");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee)
                .WithMany().IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.BaseSalary).IsRequired();
            builder.Property(x => x.BonusRate).IsRequired();
            builder.Property(x => x.ValidAfter).IsRequired();
            builder.Property(x => x.ValidBefore).IsRequired();

        }
    }
}
