using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services;

public class BasketService (IBasketRepository itemRepository)
{
    private readonly IBasketRepository _itemRepository = itemRepository;
    
    public async Task AddItem(int Id, List<Item> Items)
    {
        foreach (var item in Items)
        {
            var product = new Item(item.Name, item.Price); 
            await _itemRepository.AddItemToBasket(product); 
        }     
    }
}
