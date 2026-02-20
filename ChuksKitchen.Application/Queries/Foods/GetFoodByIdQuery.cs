namespace Application.Queries.Foods;

using MediatR;
using Domain.Entities;

public record GetFoodByIdQuery(Guid Id) : IRequest<Food?>;