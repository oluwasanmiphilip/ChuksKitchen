using FluentValidation;
using Application.Commands.Foods;

public class UpdateFoodValidator : AbstractValidator<UpdateFoodCommand>
{
    public UpdateFoodValidator()
    {
        RuleFor(f => f.Id).NotEmpty();
        RuleFor(f => f.Name).NotEmpty().MaximumLength(100);
        RuleFor(f => f.Description).NotEmpty().MaximumLength(250);
        RuleFor(f => f.Price).GreaterThan(0);
    }
}