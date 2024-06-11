using Domain.Primitives;
using Domain.ValueObject;

namespace Application.DTO.User;

public class UserResponse
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string NickName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public PaymentDetails PaymentDetails { get; set; }
    public Role Role { get; set; }
}