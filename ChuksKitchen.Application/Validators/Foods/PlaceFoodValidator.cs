using FluentValidation;
using Application.Commands.Foods;

public class PlaceFoodValidator : AbstractValidator<PlaceFoodCommand>
{
    public PlaceFoodValidator()
    {
        RuleFor(f => f.Name).NotEmpty().MaximumLength(100);
        RuleFor(f => f.Description).NotEmpty().MaximumLength(250);
        RuleFor(f => f.Price).GreaterThan(0);
    }
}