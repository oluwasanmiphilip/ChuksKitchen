namespace Application.Validators.Users;

using FluentValidation;
using Application.Commands.Users;

public class SignupUserValidator : AbstractValidator<SignupUserCommand>
{
    public SignupUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().When(x => string.IsNullOrEmpty(x.Phone));
        RuleFor(x => x.Phone).NotEmpty().When(x => string.IsNullOrEmpty(x.Email));
    }
}