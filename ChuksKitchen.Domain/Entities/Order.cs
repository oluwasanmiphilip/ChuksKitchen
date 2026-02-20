namespace Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid FoodId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties (optional, for EF Core relationships)
    public User User { get; set; }
    public Food Food { get; set; }
}