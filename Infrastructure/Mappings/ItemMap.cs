using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mappings;

public static class ItemMap
{
    public static ModelBuilder Map(this ModelBuilder modelBuilder)
    {
        return modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(c => new { c.Id });

            entity.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired();

            entity.Property(c => c.Name).IsRequired();

            entity.HasIndex(p => p.Id);
            entity.HasIndex(p => p.Name);
        });
    }
}
