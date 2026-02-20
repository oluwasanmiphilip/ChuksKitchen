using MediatR;
using Application.Commands.Foods;
using Application.Interfaces;

namespace Application.Handlers.Foods;

public class DeleteFoodHandler : IRequestHandler<DeleteFoodCommand, bool>
{
    private readonly IFoodRepository _repository;

    public DeleteFoodHandler(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}