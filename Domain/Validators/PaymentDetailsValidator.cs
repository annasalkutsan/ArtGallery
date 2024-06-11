using Domain.Primitives;
using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validators;

public class PaymentDetailsValidator:AbstractValidator<PaymentDetails>
{
    public PaymentDetailsValidator()
    {
        RuleFor(expression: x => x.FirstName)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);
              
        RuleFor(expression: x => x.LastName)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);
        
        RuleFor(expression: x => x.CardNumber)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            //пример 1234-5678-9012-3456 (16 цифр)
            .Matches(@"^(?:\d{4}[- ]?){3}\d{4}$").WithMessage(ValidationMessages.IsRight);
       
        RuleFor(expression: x => x.CheckingAccount)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            //20 цифр
            .Matches(@"^\d{20}$").WithMessage(ValidationMessages.IsRight);
    }
}