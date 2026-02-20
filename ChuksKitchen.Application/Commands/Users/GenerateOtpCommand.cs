namespace Application.Commands.Users;

using MediatR;

public record GenerateOtpCommand(Guid UserId) : IRequest<bool>;