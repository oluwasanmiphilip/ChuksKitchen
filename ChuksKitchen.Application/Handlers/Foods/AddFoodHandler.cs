using MediatR;
using Application.Commands.Foods;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Foods;

public class AddFoodHandler : IRequestHandler<AddFoodCommand, Guid>
{
    private readonly IFoodRepository _repository;

    public AddFoodHandler(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(AddFoodCommand request, CancellationToken cancellationToken)
    {
        var food = new Food(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.Price,
            true // new foods are available by default
        );

        await _repository.AddAsync(food);
        return food.Id;
    }
}