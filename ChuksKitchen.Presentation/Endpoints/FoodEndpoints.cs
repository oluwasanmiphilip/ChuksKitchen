using Application.Commands.Foods;
using Application.Queries.Foods;
using MediatR;

namespace Presentation.Endpoints;

public static class FoodEndpoints
{
    public static void MapFoodEndpoints(this WebApplication app)
    {
        // Create food
        app.MapPost("/foods", async (PlaceFoodCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        });

        // Get all foods
        app.MapGet("/foods", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetFoodsQuery());
            return Results.Ok(result);
        });

        // Get food by ID
        app.MapGet("/foods/{id}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetFoodByIdQuery(id));
            return result is not null ? Results.Ok(result) : Results.NotFound("Food not found");
        });

        // Update food
        app.MapPut("/foods/{id}", async (Guid id, UpdateFoodCommand command, IMediator mediator) =>
        {
            if (id != command.Id) return Results.BadRequest("ID mismatch");

            var result = await mediator.Send(command);
            return result ? Results.Ok("Food updated successfully") : Results.NotFound("Food not found");
        });

        // Delete food
        app.MapDelete("/foods/{id}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteFoodCommand(id));
            return result ? Results.Ok("Food deleted successfully") : Results.NotFound("Food not found");
        });
    }
}