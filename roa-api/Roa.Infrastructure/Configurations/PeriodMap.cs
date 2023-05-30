using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roa.Domain.Entities;

namespace Roa.Infrastructure.Configurations;
internal class PeriodMap : IEntityTypeConfiguration<Period>
{
    public void Configure(EntityTypeBuilder<Period> builder)
    {
        builder.ToTable("Period");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
               .UseIdentityColumn();

        builder.Property(i => i.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(i => i.Name)
               .IsUnique();

        builder.HasData(
          new Period(1, "Morning", new TimeSpan(6, 0, 0), new TimeSpan(11, 59, 59)),
          new Period(2, "Night", new TimeSpan(20, 00, 00), new TimeSpan(23, 59, 59))
        );
    }
}
