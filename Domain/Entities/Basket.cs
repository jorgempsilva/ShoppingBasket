namespace Domain.Entities;

public class Basket
{
    public string Id { get; set; } = string.Empty;
    public string BuyerId { get; set; } = string.Empty;
    public List<string> Items { get; set; } = [];
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
