using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class AuthorValidator:AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(expression: x => x.Description)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty);
              
        RuleFor(expression: x => x.NumberOfWorks)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .GreaterThanOrEqualTo(0).WithMessage("Число работ не может быть отрицательным числом.");
    }
}