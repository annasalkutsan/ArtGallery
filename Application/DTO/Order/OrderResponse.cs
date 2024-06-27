
using Domain.Primitives;

namespace Application.DTO.User;

public class OrderResponse
{
    public DateTime CreationDate { get; set; }
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid PaintingId { get; set; } // Внешний ключ для картины
    public Guid UserId { get; set; } // Внешний ключ для пользователя
    public EnumTypeStatus Status { get; set; }
}