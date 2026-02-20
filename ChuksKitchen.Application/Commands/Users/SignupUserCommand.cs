namespace Application.Commands.Users;

using MediatR;

public record SignupUserCommand(string Email, string Phone, string? ReferralCode) : IRequest<Guid>;