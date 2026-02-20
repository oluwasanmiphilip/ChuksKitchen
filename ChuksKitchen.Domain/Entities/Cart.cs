public record Cart
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public List<CartItem> Items { get; init; } = new();
}

public record CartItem
{
    public Guid Id { get; init; }            // <-- added PK
    public Guid FoodId { get; init; }
    public int Quantity { get; set; }
}