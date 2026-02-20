using Application.Commands.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class SignupUserHandler : IRequestHandler<SignupUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public SignupUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(SignupUserCommand request, CancellationToken cancellationToken)
    {
        // Check for duplicates (repository exposes ExistsByEmailOrPhoneAsync)
        var exists = await _userRepository.ExistsByEmailOrPhoneAsync(request.Email, request.Phone);

        if (exists)
            throw new InvalidOperationException("Email or phone number already exists.");

        // Validate referral code if provided
        if (!string.IsNullOrEmpty(request.ReferralCode))
        {
            var referrer = await _userRepository.GetByReferralCodeAsync(request.ReferralCode);
            if (referrer is null)
                throw new InvalidOperationException("Invalid or expired referral code.");
        }

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PhoneNumber = request.Phone,
            ReferralCode = request.ReferralCode ?? string.Empty,
            SignupStatus = "Pending",
            Verified = false,
            IsActive = true,
            OtpExpiry = DateTime.UtcNow.AddMinutes(15)
        };

        await _userRepository.AddAsync(newUser);
        return newUser.Id;
    }
}