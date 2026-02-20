using Application.Commands.Orders;
using FluentValidation;

namespace Application.Validators.Orders;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator()
    {
        RuleFor(o => o.Id).NotEmpty();
    }
}