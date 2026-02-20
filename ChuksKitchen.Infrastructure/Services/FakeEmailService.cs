using Application.Interfaces;

namespace Infrastructure.Services;

public class FakeEmailService : IEmailService
{
    public Task SendAsync(string to, string subject, string body)
    {
        Console.WriteLine($"[FAKE EMAIL] To: {to}, Subject: {subject}, Body: {body}");
        return Task.CompletedTask;
    }
}