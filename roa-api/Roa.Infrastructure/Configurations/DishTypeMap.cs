using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roa.Domain.Entities;

namespace Roa.Infrastructure.Configurations;
internal class DishTypeMap : IEntityTypeConfiguration<DishType>
{
    public void Configure(EntityTypeBuilder<DishType> builder)
    {
        builder.ToTable("DishType");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
               .UseIdentityColumn();

        builder.Property(i => i.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(i => i.Name)
               .IsUnique();

        builder.HasData(
          new DishType(1, "Entree"),
          new DishType(2, "Side"),
          new DishType(3, "Drink"),
          new DishType(4, "Dessert")
        );
    }
}
