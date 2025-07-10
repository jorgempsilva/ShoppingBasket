namespace Domain.Entities;

public class Item(string name, decimal price)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public decimal Price { get; private set; } = price;
}
