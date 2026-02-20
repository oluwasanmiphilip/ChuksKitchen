namespace Application.Commands.Foods;

using MediatR;
using System;

public record AddFoodCommand(string Name, string Description, decimal Price) : IRequest<Guid>;