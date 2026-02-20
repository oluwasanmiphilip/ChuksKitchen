namespace Application.Queries.Users;

using MediatR;
using Application.DTOs.Users;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;