using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class PayrollConfig : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.ToTable("Payroll");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Employee).WithMany()
                .HasForeignKey(x=> x.EmployeeId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WorkTime).WithMany()
                .HasForeignKey(x => x.WorkTimeId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PayProfile).WithMany()
                .HasForeignKey(x => x.PayProfileId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
