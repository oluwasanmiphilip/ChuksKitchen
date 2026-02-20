using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _context;

    public FoodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Food?> GetByIdAsync(Guid id)
        => await _context.Foods.FindAsync(id);

    public async Task<IEnumerable<Food>> GetAllAsync()
        => await _context.Foods.ToListAsync();

    public async Task AddAsync(Food food)
    {
        await _context.Foods.AddAsync(food);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Food food)
    {
        var existing = await _context.Foods.FindAsync(food.Id);
        if (existing is null) return false;

        _context.Entry(existing).CurrentValues.SetValues(food);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var food = await _context.Foods.FindAsync(id);
        if (food is null) return false;

        _context.Foods.Remove(food);
        await _context.SaveChangesAsync();
        return true;
    }
}