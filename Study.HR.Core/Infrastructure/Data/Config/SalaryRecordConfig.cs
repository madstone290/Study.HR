using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class SalaryRecordConfig : IEntityTypeConfiguration<SalaryRecord>
    {
        public void Configure(EntityTypeBuilder<SalaryRecord> builder)
        {
            builder.ToTable("SalaryRecord");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee).WithMany()
                .HasForeignKey(x=> x.EmployeeId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Month).IsRequired();
            builder.HasOne(x => x.WorkTime).WithMany()
                .HasForeignKey(x => x.WorkTimeId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.MinutesWorked).IsRequired();
            builder.HasOne(x => x.EmployeeSalary).WithMany()
                .HasForeignKey(x => x.EmployeeSalaryId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.BaseSalary).IsRequired();
            builder.Property(x => x.BonusRate).IsRequired();
        }
    }
}
