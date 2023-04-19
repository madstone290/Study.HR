using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class WorkTimeConfig : IEntityTypeConfiguration<WorkTime>
    {
        public void Configure(EntityTypeBuilder<WorkTime> builder)
        {
            builder.ToTable("WorkTime");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Month).IsRequired();
            builder.Property(x => x.MinutesWorked).IsRequired();
        }
    }
}
