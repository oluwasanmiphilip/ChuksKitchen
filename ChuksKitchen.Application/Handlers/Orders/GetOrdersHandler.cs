using MediatR;
using Application.Queries.Orders;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Orders;

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _repository;

    public GetOrdersHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}