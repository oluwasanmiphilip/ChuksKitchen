using MediatR;
using Application.Queries.Orders;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Orders;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order?>
{
    private readonly IOrderRepository _repository;

    public GetOrderByIdHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}