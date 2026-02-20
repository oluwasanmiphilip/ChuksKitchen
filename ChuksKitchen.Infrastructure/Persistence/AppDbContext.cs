using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Use deterministic GUIDs so seeded Order can reference seeded User/Food
        var food1Id = new Guid("11111111-1111-1111-1111-111111111111");
        var food2Id = new Guid("22222222-2222-2222-2222-222222222222");
        var food3Id = new Guid("33333333-3333-3333-3333-333333333333");
        var userId = new Guid("44444444-4444-4444-4444-444444444444");
        var orderId = new Guid("55555555-5555-5555-5555-555555555555");

        modelBuilder.Entity<Food>().HasData(
            new { Id = food1Id, Name = "Jollof Rice", Description = "Classic Nigerian party rice with tomato base", Price = 2500m, IsAvailable = true },
            new { Id = food2Id, Name = "Suya", Description = "Spicy grilled beef skewers", Price = 1500m, IsAvailable = true },
            new { Id = food3Id, Name = "Pounded Yam & Egusi", Description = "Yam flour served with melon seed soup", Price = 3000m, IsAvailable = true }
        );

        // Match the User record's property names: Id, Email, PhoneNumber, ReferralCode, Verified, IsActive, SignupStatus, OtpCode, OtpExpiry
        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = userId,
                Email = "oluwasanmi@example.com",
                PhoneNumber = "08012345678",
                ReferralCode = "REF123",
                Verified = true,
                IsActive = true,
                SignupStatus = "Completed",
                OtpCode = string.Empty,
                OtpExpiry = (DateTime?)null
            }
        );

        // Use a fixed, hard-coded DateTime to avoid EF Core's PendingModelChangesWarning
        var seedCreatedAt = new DateTime(2026, 02, 20, 0, 0, 0, DateTimeKind.Utc);

        // Seed an Order that references the seeded User and a seeded Food
        modelBuilder.Entity<Order>().HasData(
            new { Id = orderId, UserId = userId, FoodId = food1Id, Quantity = 2, CreatedAt = seedCreatedAt }
        );

        // --- NEW: Configure CartItem as an owned collection of Cart ---
        modelBuilder.Entity<Cart>(cart =>
        {
            cart.HasKey(c => c.Id);

            cart.OwnsMany(
                c => c.Items,
                a =>
                {
                    // create a shadow FK column CartId in the owned table
                    a.WithOwner().HasForeignKey("CartId");

                    // give each CartItem its own key (EF requires a PK for the owned collection table)
                    a.Property<Guid>("Id");
                    a.HasKey("Id");

                    // Map owned properties
                    a.Property(ci => ci.FoodId).IsRequired();
                    a.Property(ci => ci.Quantity).IsRequired();

                    // Optional: map to its own table
                    a.ToTable("CartItems");
                });
        });
    }
}