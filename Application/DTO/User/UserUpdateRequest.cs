using Domain.Primitives;
using Domain.ValueObject;

namespace Application.DTO.User;

public class UserUpdateRequest
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public PaymentDetails? PaymentDetails { get; set; }
    public Role Role { get; set; }
}