using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

public class PendingSignupCleanupService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public PendingSignupCleanupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var cutoff = DateTime.UtcNow.AddHours(-1); // 1 hour timeout
            var abandonedUsers = await db.Users
                .Where(u => u.SignupStatus == "Pending" && u.OtpExpiry < cutoff)
                .ToListAsync(stoppingToken);

            if (abandonedUsers.Any())
            {
                db.Users.RemoveRange(abandonedUsers);
                await db.SaveChangesAsync(stoppingToken);
            }

            await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken); // run every 30 mins
        }
    }
}