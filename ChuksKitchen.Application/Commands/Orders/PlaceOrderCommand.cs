namespace Application.Commands.Orders;

using MediatR;

public record PlaceOrderCommand(Guid UserId, Guid FoodId, int Quantity) : IRequest<Guid>;