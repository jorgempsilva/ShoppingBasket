using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mappings;

public static class BasketMap
{
    public static ModelBuilder Map(this ModelBuilder modelBuilder)
    {
        return modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(c => new { c.Id });
            entity.Property(c => c.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(c => c.CreatedDate).IsRequired();
            entity.Property(c => c.UpdatedDate).IsRequired();
            entity.Property(c => c.BuyerId).IsRequired();

            entity.HasIndex(p => p.Id);
            entity.HasIndex(p => p.BuyerId);
        });
    }
}
