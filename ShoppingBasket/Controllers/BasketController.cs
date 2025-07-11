﻿using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController(BasketService basketService) : ControllerBase
{
    private readonly BasketService _basketService = basketService;
   
    [HttpPost("{Id}/items")]
    public IActionResult AddItemToBasket(int Id, [FromBody] List<Item> items)
    {
         _basketService.AddItem(Id, items);
        
        return Ok();
    }
}
