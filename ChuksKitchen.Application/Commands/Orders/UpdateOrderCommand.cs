namespace Application.Commands.Orders;

using MediatR;

public record UpdateOrderCommand(Guid Id, int Quantity) : IRequest<bool>;