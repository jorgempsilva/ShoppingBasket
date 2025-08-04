using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BasketRepository(SqlContext sqlContext) : IBasketRepository  
{
    private readonly SqlContext _context = sqlContext;

    public async Task AddItemToBasket(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var itemExists = await _context.Items
            .AsNoTracking()
            .AnyAsync(i => i.Id == item.Id);

        if (itemExists)
            throw new ArgumentException($"This item id {item.Id} already exists.", nameof(item));

        try
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("Error saving on database", ex);
        }
    }
}
