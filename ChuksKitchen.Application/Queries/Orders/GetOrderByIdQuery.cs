namespace Application.Queries.Orders;

using MediatR;
using Domain.Entities;

public record GetOrderByIdQuery(Guid Id) : IRequest<Order?>;