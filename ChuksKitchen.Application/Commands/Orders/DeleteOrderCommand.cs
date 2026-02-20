namespace Application.Commands.Orders;

using MediatR;

public record DeleteOrderCommand(Guid Id) : IRequest<bool>;