using Application.Commands.Carts;
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Carts;

public class GetCartHandler : IRequestHandler<GetCartQuery, Cart?>
{
    private readonly ICartRepository _repository;

    public GetCartHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Cart?> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByUserIdAsync(request.UserId);
    }
}