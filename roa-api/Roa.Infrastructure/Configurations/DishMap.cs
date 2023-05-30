using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roa.Domain.Entities;

namespace Roa.Infrastructure.Configurations;
internal class DishMap : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dish");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
               .UseIdentityColumn();

        builder.Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(d => d.Name)
               .IsUnique();

        builder.HasOne(i => i.DishType)
               .WithMany(i => i.Dishes)
               .HasForeignKey(i => i.DishTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Period)
               .WithMany(i => i.Dishes)
               .HasForeignKey(i => i.PeriodId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
          new Dish(1, "Eggs", 1, 1),
          new Dish(2, "Steak", 1, 2),
          new Dish(3, "Toast", 2, 1),
          new Dish(4, "Potato", 2, 2),
          new Dish(5, "Coffee", 3, 1),
          new Dish(6, "Wine", 3, 2),
          new Dish(7, "Cake", 4, 2)
        );
    }
}
