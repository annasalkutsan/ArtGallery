using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class OrderValidator:AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(x=>x.OrderDate)
            .NotNull().WithMessage(x=>ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x=>ValidationMessages.IsEmpty)
            .Equal(DateTime.Today).WithMessage("Дата заказа должна быть сегодняшней");
    }
}