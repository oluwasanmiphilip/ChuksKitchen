using Application.Commands.Carts;
using MediatR;

namespace Application.Handlers.Carts;

public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartCommand, bool>
{
    private readonly ICartRepository _repository;

    public RemoveFromCartHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByUserIdAsync(request.UserId);
        if (cart is null) return false;

        await _repository.RemoveItemAsync(request.UserId, request.FoodId);
        return true;
    }
}