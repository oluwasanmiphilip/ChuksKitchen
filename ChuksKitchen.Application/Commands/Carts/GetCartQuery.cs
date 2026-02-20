namespace Application.Commands.Carts;

using MediatR;
using Domain.Entities;

public record GetCartQuery(Guid UserId) : IRequest<Cart?>;