using Application.Interfaces;
using Application.Validators.Users;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Endpoints;

namespace ChuksKitchen.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database connection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection
            if (builder.Environment.IsDevelopment())
            {
                // Use fake email service in development
                builder.Services.AddScoped<IEmailService, FakeEmailService>();
            }
            else
            {
                // Use real SMTP email service in production
                builder.Services.Configure<SmtpSettings>(
                    builder.Configuration.GetSection("SmtpSettings"));
                builder.Services.AddScoped<IEmailService, SmtpEmailService>();
            }

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFoodRepository, FoodRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Application.Behaviors.ValidationBehavior<,>));
            // MediatR + CQRS
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<SignupUserHandler>();
            });

            // FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<SignupUserValidator>();

            // Hosted Services (background jobs)
            builder.Services.AddHostedService<PendingSignupCleanupService>();

            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Map endpoints (instead of controllers)
            app.MapUserEndpoints();
            app.MapFoodEndpoints();
            app.MapOrderEndpoints();

            app.Run();
        }
    }
}