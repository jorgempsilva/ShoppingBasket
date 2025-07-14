using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
{
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=db;Database=ShoppingBasketDB;User Id=sa;Password=12345678@A;TrustServerCertificate=True")
            .EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        BasketMap.Map(modelBuilder);
        ItemMap.Map(modelBuilder);
    }
}
