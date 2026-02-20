using FluentValidation;
using Application.Commands.Users;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.Id).NotEmpty();
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.Phone).NotEmpty().MaximumLength(15);
    }
}