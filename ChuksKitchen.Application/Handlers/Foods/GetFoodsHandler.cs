using MediatR;
using Application.Queries.Foods;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Foods;

public class GetFoodsHandler : IRequestHandler<GetFoodsQuery, IEnumerable<Food>>
{
    private readonly IFoodRepository _repository;

    public GetFoodsHandler(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Food>> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}