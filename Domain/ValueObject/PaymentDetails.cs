using System.Reflection;
using Domain.Validators;
using FluentValidation;

namespace Domain.ValueObject;
public class PaymentDetails:BaseValueObject
{
    public PaymentDetails(){}
    public PaymentDetails(string firstName, string lastName, string? cardNumber, string checkingAccount)
    {
        FirstName = firstName;
        LastName = lastName;
        CardNumber = cardNumber;
        CheckingAccount = checkingAccount;
        
        //var validator = new PaymentDetailsValidator();
        //validator.ValidateAndThrow(this);
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? CardNumber { get; set; }
    public string CheckingAccount { get; set; }
    /// <summary>
    /// Реализация DeepCompare с рефлексией
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool DeepCompare(PaymentDetails other)
    {
        if (other == null)
            return false;

        // получаем все свойства объекта текущего экземпляра 
        PropertyInfo[] properties = typeof(PaymentDetails).GetProperties();

        // проходимся по каждому свойству
        foreach (var property in properties)
        {
            // получаем значения свойств для текущего экземпляра (this) и для другого объекта (other)
            var thisValue = property.GetValue(this);
            var otherValue = property.GetValue(other);

            // сравниваем значения свойств
            if (!Equals(thisValue, otherValue))
                return false;
        }

        // если все свойства эквивалентны
        return true;
    }
    /// <summary>
    /// Реализация DeepClone для FullName
    /// </summary>
    /// <returns></returns>
    public PaymentDetails DeepClone()
    {
        return new PaymentDetails(FirstName, LastName, CardNumber, CheckingAccount);
    }
    
    public PaymentDetails Update(string? firstName, string? lastName, string? cardNumber, string? checkingAccount)
    {
        if (firstName is not null)
        {
            FirstName = firstName;
        }
        if (lastName is not null)
        {
            LastName = lastName;
        }
        if (cardNumber is not null)
        {
            CardNumber = cardNumber;
        }
        if (checkingAccount is not null)
        {
            CheckingAccount = checkingAccount;
        }
        
       // var validator = new PaymentDetailsValidator();
        //validator.Validate(this);
        return this;
    }
}