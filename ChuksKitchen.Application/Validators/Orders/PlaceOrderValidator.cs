using FluentValidation;
using Application.Commands.Orders;

public class PlaceOrderValidator : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderValidator()
    {
        RuleFor(o => o.UserId).NotEmpty();
        RuleFor(o => o.FoodId).NotEmpty();
        RuleFor(o => o.Quantity).GreaterThan(0);
    }
}