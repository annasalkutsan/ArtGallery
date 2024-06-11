using Domain.Entities;
using Domain.Primitives;
using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validators;

public class PaintingValidator:AbstractValidator<Painting>
{
    public PaintingValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty);
        RuleFor(x => x.Price)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .GreaterThanOrEqualTo(0).WithMessage("Стоимость не может быть отрицательным числом.");
    }
}