namespace Application.Commands.Users;

using MediatR;

public record UpdateUserCommand(Guid Id, string Email, string Phone) : IRequest<bool>;