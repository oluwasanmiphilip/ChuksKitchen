namespace Application.Queries.Orders;

using MediatR;
using Domain.Entities;

public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;