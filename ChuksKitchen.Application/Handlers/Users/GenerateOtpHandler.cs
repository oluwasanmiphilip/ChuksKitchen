using MediatR;
using Application.Commands.Users;
using Application.Interfaces;
using System.Security.Cryptography;
using Domain.Entities;

namespace Application.Handlers.Users;

public class GenerateOtpHandler : IRequestHandler<GenerateOtpCommand, bool>
{
    private readonly IUserRepository _repository;
    private readonly IEmailService _emailService;

    public GenerateOtpHandler(IUserRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task<bool> Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.UserId);
        if (user is null) return false;

        var otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();
        var updatedUser = user with { OtpCode = otp, OtpExpiry = DateTime.UtcNow.AddMinutes(5) };

        await _repository.UpdateAsync(updatedUser);

        await _emailService.SendAsync(user.Email, "Your OTP Code", $"Your verification code is {otp}");
        return true;
    }
}