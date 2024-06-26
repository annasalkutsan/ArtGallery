using Domain.Primitives;
using Domain.Validators;
using Domain.ValueObject;
using FluentValidation;
namespace Domain.Entities;

public class User:BaseEntity
{
    //для EF 
    public User(){}
    public User(string nickName, string email, PaymentDetails paymentDetails, EnumTypeRoles role, List<Order> orders)
    {
        NickName = nickName;
        Email = email;
        PaymentDetails = paymentDetails;
        Role = role;
        Orders = orders;
        //var validator = new UserValidator();
        //validator.ValidateAndThrow(this);
    }
    public string NickName { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public string Email { get; set; }
    public PaymentDetails PaymentDetails { get; set; }
    public EnumTypeRoles Role { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    
    public User Update(string? email, string? firstName, string? lastName, string? cardNumber, string? checkingAccount, EnumTypeRoles role)
    {
        PaymentDetails.Update(firstName, lastName, cardNumber, checkingAccount);
        if (email is not null)
        {
            Email = email;
        }
        Role = role;

       // var validator = new UserValidator();
        //validator.ValidateAndThrow(this);

        return this;
    }
}