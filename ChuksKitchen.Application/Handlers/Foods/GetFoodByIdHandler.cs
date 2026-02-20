using MediatR;
using Application.Queries.Foods;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Foods;

public class GetFoodByIdHandler : IRequestHandler<GetFoodByIdQuery, Food?>
{
    private readonly IFoodRepository _repository;

    public GetFoodByIdHandler(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<Food?> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}