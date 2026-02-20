using Application.Commands.Foods;
using FluentValidation;

namespace Application.Validators.Foods;

public class DeleteFoodValidator : AbstractValidator<DeleteFoodCommand>
{
    public DeleteFoodValidator()
    {
        RuleFor(f => f.Id).NotEmpty();
    }
}