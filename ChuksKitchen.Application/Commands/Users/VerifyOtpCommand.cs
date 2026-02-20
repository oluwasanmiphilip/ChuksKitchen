namespace Application.Commands.Users;

using MediatR;

public record VerifyOtpCommand(Guid UserId, string OtpCode) : IRequest<bool>;