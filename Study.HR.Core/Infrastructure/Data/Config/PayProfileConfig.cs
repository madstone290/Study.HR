using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.HR.Core.Domain.Entities;

namespace Study.HR.Core.Infrastructure.Data.Config
{
    public class PayProfileConfig : IEntityTypeConfiguration<PayProfile>
    {
        public void Configure(EntityTypeBuilder<PayProfile> builder)
        {
            builder.ToTable("PayProfile");
            builder.HasKey(x => x.Id);
        }
    }
}
