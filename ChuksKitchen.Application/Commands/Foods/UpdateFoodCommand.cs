namespace Application.Commands.Foods;

using MediatR;

public record UpdateFoodCommand(Guid Id, string Name, string Description, decimal Price, bool IsAvailable) : IRequest<bool>;