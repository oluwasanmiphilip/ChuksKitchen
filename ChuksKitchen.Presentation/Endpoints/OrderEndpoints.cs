namespace Presentation.Endpoints;

using Application.Commands.Orders;
using Application.Queries.Orders;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        // Place new order
        app.MapPost("/orders", async (PlaceOrderCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        });

        // Update order
        app.MapPut("/orders/{id}", async (Guid id, UpdateOrderCommand command, IMediator mediator) =>
        {
            if (id != command.Id) return Results.BadRequest("ID mismatch");

            var result = await mediator.Send(command);
            return result ? Results.Ok("Order updated successfully") : Results.NotFound("Order not found");
        });

        // Cancel order
        app.MapDelete("/orders/{id}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteOrderCommand(id));
            return result ? Results.Ok("Order cancelled successfully") : Results.NotFound("Order not found");
        });

        // Get all orders
        app.MapGet("/orders", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetOrdersQuery());
            return Results.Ok(result);
        });
        //c;    
        // Existing POST, PUT, DELETE, GET all...

        // Get order by ID
        app.MapGet("/orders/{id}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetOrderByIdQuery(id));
            return result is not null ? Results.Ok(result) : Results.NotFound("Order not found");
        });


    }
}
