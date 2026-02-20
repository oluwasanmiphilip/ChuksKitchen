using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Food)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.User)   // eager load user
            .Include(o => o.Food)   // eager load food
            .ToListAsync();
    }
    public async Task<bool> UpdateAsync(Order order)
    {
        var existing = await _context.Orders.FindAsync(order.Id);
        if (existing is null) return false;

        existing.Quantity = order.Quantity;

        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order is null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
    


}