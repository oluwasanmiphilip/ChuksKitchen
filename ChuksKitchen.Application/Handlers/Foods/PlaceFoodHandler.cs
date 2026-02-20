using MediatR;
using Application.Commands.Foods;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Foods;

public class PlaceFoodHandler : IRequestHandler<PlaceFoodCommand, Food>
{
    private readonly IFoodRepository _repository;

    public PlaceFoodHandler(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<Food> Handle(PlaceFoodCommand request, CancellationToken cancellationToken)
    {
        var food = new Food(Guid.NewGuid(), "Pizza", "Delicious pizza", 12.99m, true);
        await _repository.AddAsync(food);
        return food;
    }
}