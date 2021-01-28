using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Uwp.Model
{
    public class IdentRiskConfiguration : IEntityTypeConfiguration<IdentRisk>
    {
        public void Configure(EntityTypeBuilder<IdentRisk> builder)
        {
            builder.ToTable("IDENTRISK");
            builder.Property(p => p.Id)
                .HasColumnName("ID");
            builder.Property(p => p.Name)
                .HasColumnName("NAME");
        }
    }
}
