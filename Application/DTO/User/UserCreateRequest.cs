using Domain.Primitives;
using Domain.ValueObject;

namespace Application.DTO.User;

public class UserCreateRequest
{
    public string NickName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public PaymentDetails PaymentDetails { get; set; }
    public EnumTypeRoles Role { get; set; }
}