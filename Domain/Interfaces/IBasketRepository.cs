﻿using Domain.Entities;

namespace Domain.Interfaces;

public interface IBasketRepository
{
    void AddItemToBasket(Item item);
}
