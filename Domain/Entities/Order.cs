using Domain.Primitives;
using Domain.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Order:BaseEntity
{
    public Order(){}

    public Order(DateTime orderDate, Status status, Painting painting, User user)
    {
        OrderDate = orderDate;
        Status = status;
        Painting = painting;
        PaintingId = painting.Id;
        User = user;
        UserId = user.Id;

        //var validator = new OrderValidator();
       // validator.ValidateAndThrow(this);
    }
    public DateTime OrderDate { get; set; }
    public Painting Painting { get; set; }
    public Guid PaintingId { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Status Status { get; set; }
    
    public Order Update(DateTime? orderDate, Status? status)
    {
        if (orderDate.HasValue)
        {
            OrderDate = orderDate.Value;
        }

        if (status.HasValue)
        {
            Status = status.Value;
        }
        // var validator = new OrderValidator();
        //validator.ValidateAndThrow(this);

        return this;
    }

}