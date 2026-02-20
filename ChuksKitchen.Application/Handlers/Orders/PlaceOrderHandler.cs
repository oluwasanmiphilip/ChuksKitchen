using MediatR;
using Application.Commands.Orders;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Orders;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Guid>
{
    private readonly IOrderRepository _repository;

    public PlaceOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            FoodId = request.FoodId,
            Quantity = request.Quantity,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(order);
        return order.Id;
    }
}