namespace Application.Commands.Carts;

using MediatR;
using Domain.Entities;

public record AddToCartCommand(Guid UserId, Guid FoodId, int Quantity) : IRequest<Cart?>;