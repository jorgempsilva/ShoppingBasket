using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class BasketRepository : IBasketRepository  
{
    private readonly Dictionary<Guid, Item> _items = [];

    public void AddItemToBasket(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (_items.ContainsKey(item.Id))
            throw new ArgumentException("Item with the same ID already exists.", nameof(item));

        _items.Add(item.Id, item);
    }
}
