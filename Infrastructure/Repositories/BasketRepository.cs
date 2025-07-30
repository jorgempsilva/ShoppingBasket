using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class BasketRepository(SqlContext sqlContext) : IBasketRepository  
{
    private readonly SqlContext _context = sqlContext;

    public async Task AddItemToBasket(Item item) 
    {
        ArgumentNullException.ThrowIfNull(item);

        if (_context.Items.Contains(item))
            throw new ArgumentException("Item with the same ID already exists.", nameof(item));

        await _context.Items.AddAsync(item);
    }
}
