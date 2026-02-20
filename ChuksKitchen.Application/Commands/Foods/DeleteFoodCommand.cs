namespace Application.Commands.Foods;

using MediatR;

public record DeleteFoodCommand(Guid Id) : IRequest<bool>;