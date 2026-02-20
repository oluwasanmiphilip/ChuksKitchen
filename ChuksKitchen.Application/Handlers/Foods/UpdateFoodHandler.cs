using MediatR;
using Application.Commands.Foods;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Foods;

public class UpdateFoodHandler : IRequestHandler<UpdateFoodCommand, bool>
{
    private readonly IFoodRepository _repository;

    public UpdateFoodHandler(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        var food = new Food(request.Id, request.Name, request.Description, request.Price, request.IsAvailable);
        return await _repository.UpdateAsync(food);
    }
}