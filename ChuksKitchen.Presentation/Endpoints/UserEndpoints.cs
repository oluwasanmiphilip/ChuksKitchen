namespace Presentation.Endpoints;

using Application.Commands.Users;
using Application.Queries.Users;
using MediatR;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        // Signup command
        app.MapPost("/users/signup", async (SignupUserCommand command, IMediator mediator) =>
        {
            try
            {
                var userId = await mediator.Send(command);
                return Results.Ok(new { UserId = userId, Message = "Signup successful. Please verify your account via OTP." });
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { Error = ex.Message });
            }
        });

        // Query user by Id
        app.MapGet("/users/{id}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetUserByIdQuery(id));
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });
        app.MapPost("/users/{id}/generate-otp", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GenerateOtpCommand(id));
            return result ? Results.Ok("OTP sent") : Results.NotFound("User not found");
        });

        app.MapPost("/users/{id}/verify-otp", async (Guid id, string otpCode, IMediator mediator) =>
        {
            var result = await mediator.Send(new VerifyOtpCommand(id, otpCode));
            return result ? Results.Ok("User verified successfully") : Results.BadRequest("Invalid or expired OTP");
        });
        
    }
}