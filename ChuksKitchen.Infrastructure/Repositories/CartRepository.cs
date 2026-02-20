using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext context) => _context = context;

    public async Task<Cart?> GetByUserIdAsync(Guid userId)
        => await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

    public async Task AddItemAsync(Guid userId, Guid foodId, int quantity)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart is null)
        {
            cart = new Cart
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items = new List<CartItem>
                {
                    new CartItem { Id = Guid.NewGuid(), FoodId = foodId, Quantity = quantity }
                }
            };
            _context.Carts.Add(cart);
        }
        else
        {
            var item = cart.Items.FirstOrDefault(i => i.FoodId == foodId);
            if (item is null)
            {
                cart.Items.Add(new CartItem { Id = Guid.NewGuid(), FoodId = foodId, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
            _context.Carts.Update(cart);
        }

        await _context.SaveChangesAsync();
    }

    public async Task RemoveItemAsync(Guid userId, Guid foodId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart is null) return;

        var item = cart.Items.FirstOrDefault(i => i.FoodId == foodId);
        if (item is null) return;

        cart.Items.Remove(item);

        if (!cart.Items.Any())
            _context.Carts.Remove(cart);
        else
            _context.Carts.Update(cart);

        await _context.SaveChangesAsync();
    }

    public async Task ClearAsync(Guid userId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart is null) return;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();
    }
}