using Domain.Primitives;
using Domain.Validators;
using Domain.ValueObject;
using FluentValidation;
using Domain.Validators;
namespace Domain.Entities;

public class User:BaseEntity
{
    //для EF 
    public User(){}
    public User(string nickName, string password, string email, PaymentDetails paymentDetails, Role role, List<Order> orders)
    {
        NickName = nickName;
        Password = password;
        Email = email;
        PaymentDetails = paymentDetails;
        Role = role;
        Orders = orders;
        //var validator = new UserValidator();
        //validator.ValidateAndThrow(this);
    }
    public string NickName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public PaymentDetails PaymentDetails { get; set; }
    public Role Role { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    
    public User Update(string? email, string? firstName, string? lastName, string? cardNumber, string? checkingAccount, Role role)
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