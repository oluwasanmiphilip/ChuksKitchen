using FluentValidation;
using Application.Commands.Orders;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(o => o.Id).NotEmpty();
        RuleFor(o => o.Quantity).GreaterThan(0);
    }
}