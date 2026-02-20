using Application.Commands.Carts;
using MediatR;

namespace Application.Handlers.Carts;

public class AddToCartHandler : IRequestHandler<AddToCartCommand, Cart?>
{
    private readonly ICartRepository _repository;

    public AddToCartHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Cart?> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        await _repository.AddItemAsync(request.UserId, request.FoodId, request.Quantity);
        return await _repository.GetByUserIdAsync(request.UserId);
    }
}