using MediatR;
using Application.Commands.Orders;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Orders;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _repository;

    public UpdateOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = request.Id,
            Quantity = request.Quantity
        };

        return await _repository.UpdateAsync(order);
    }
}