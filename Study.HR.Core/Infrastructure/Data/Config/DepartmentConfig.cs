using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UpperDepartment).WithMany()
                .HasForeignKey(x => x.UpperDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
