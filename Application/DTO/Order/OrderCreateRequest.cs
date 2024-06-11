
using Domain.Primitives;

namespace Application.DTO.User;

public class OrderCreateRequest
{
    public DateTime OrderDate { get; set; }
    public Guid PaintingId { get; set; } // Внешний ключ для картины
    public Guid UserId { get; set; } // Внешний ключ для пользователя
    public Status Status { get; set; }
}