using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.NickName)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(@"^@").WithMessage(ValidationMessages.IsRight);

        RuleFor(x => x.Email)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\n").WithMessage(x => ValidationMessages.IsRight);
    }
}