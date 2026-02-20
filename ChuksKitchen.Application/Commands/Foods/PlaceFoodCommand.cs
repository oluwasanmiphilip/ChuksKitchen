namespace Application.Commands.Foods;

using MediatR;
using Domain.Entities;

public record PlaceFoodCommand(string Name, string Description, decimal Price) : IRequest<Food>;