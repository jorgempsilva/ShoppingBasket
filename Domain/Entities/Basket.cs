namespace Domain.Entities;

public class Basket
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BuyerId { get; set; }
    public List<Item> Items { get; set; } = [];
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public decimal TotalPrice { get; set; }
}
