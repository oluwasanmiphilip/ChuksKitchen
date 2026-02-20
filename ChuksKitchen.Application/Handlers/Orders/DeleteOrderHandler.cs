using MediatR;
using Application.Commands.Orders;
using Application.Interfaces;

namespace Application.Handlers.Orders;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _repository;

    public DeleteOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}