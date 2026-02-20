namespace Application.Queries.Foods;

using MediatR;
using Domain.Entities;

public record GetFoodsQuery() : IRequest<IEnumerable<Food>>;