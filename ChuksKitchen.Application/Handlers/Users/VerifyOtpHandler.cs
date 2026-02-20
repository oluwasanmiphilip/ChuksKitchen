using MediatR;
using Application.Commands.Users;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Users;

public class VerifyOtpHandler : IRequestHandler<VerifyOtpCommand, bool>
{
    private readonly IUserRepository _repository;

    public VerifyOtpHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.UserId);
        if (user is null || user.OtpCode is null || user.OtpExpiry is null)
            return false;

        // OTP expired or invalid
        if (user.OtpCode != request.OtpCode || user.OtpExpiry < DateTime.UtcNow)
        {
            var failedUser = user with { SignupStatus = "Failed" };
            await _repository.UpdateAsync(failedUser);
            return false;
        }

        // OTP valid
        var verifiedUser = user with
        {
            Verified = true,
            OtpCode = null,
            OtpExpiry = null,
            SignupStatus = "Verified"
        };

        await _repository.UpdateAsync(verifiedUser);
        return true;
    }
}