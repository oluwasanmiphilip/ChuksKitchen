namespace Application.Commands.Carts;

using MediatR;

public record RemoveFromCartCommand(Guid UserId, Guid FoodId) : IRequest<bool>;