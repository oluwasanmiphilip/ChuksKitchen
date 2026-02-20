using Application.Commands.Foods;
using FluentValidation;

namespace Application.Validators.Foods;

public class AddFoodValidator : AbstractValidator<AddFoodCommand>
{
    public AddFoodValidator()
    {
        RuleFor(f => f.Name).NotEmpty().MaximumLength(100);
        RuleFor(f => f.Description).NotEmpty().MaximumLength(250);
        RuleFor(f => f.Price).GreaterThan(0);
    }
}