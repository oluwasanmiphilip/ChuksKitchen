using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByReferralCodeAsync(string referralCode)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.ReferralCode == referralCode);
    }

    public async Task<bool> ExistsByEmailOrPhoneAsync(string email, string phone)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email || u.PhoneNumber == phone);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        var existing = await _context.Users.FindAsync(user.Id);
        if (existing is null)
        {
            // No-op if not found. Alternatively throw if you want stricter behavior.
            return;
        }

        // Replace values using EF Core
        _context.Entry(existing).CurrentValues.SetValues(user);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeactivateAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null) return false;

        // Soft delete: mark inactive (if you add IsActive flag)
        var updatedUser = user with { Verified = false, IsActive = false };
        _context.Entry(user).CurrentValues.SetValues(updatedUser);

        await _context.SaveChangesAsync();
        return true;
    }
}