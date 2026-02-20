using Application.Commands.Carts;
using MediatR;

public static class CartEndpoints
{
    public static void MapCartEndpoints(this WebApplication app)
    {
        app.MapPost("/users/{userId}/cart/add", async (Guid userId, Guid foodId, int quantity, IMediator mediator) =>
        {
            var result = await mediator.Send(new AddToCartCommand(userId, foodId, quantity));
            return Results.Ok(result);
        });

        app.MapDelete("/users/{userId}/cart/remove/{foodId}", async (Guid userId, Guid foodId, IMediator mediator) =>
        {
            var result = await mediator.Send(new RemoveFromCartCommand(userId, foodId));
            return result ? Results.Ok("Item removed") : Results.NotFound("Item not found");
        });

        app.MapGet("/users/{userId}/cart", async (Guid userId, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCartQuery(userId));
            return Results.Ok(result);
        });
    }
}