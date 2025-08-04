using Domain.Entities;

namespace Domain.Interfaces;

public interface IBasketRepository
{
    Task AddItemToBasket(Item item);
}
