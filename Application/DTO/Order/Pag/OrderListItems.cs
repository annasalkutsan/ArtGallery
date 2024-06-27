using Domain.Primitives;

namespace Application.DTO.Order.Pag
{
    /// <summary>
    ///     new
    /// </summary>
    public class OrderListItems
    {
        //  Тут ты можешь изменить любой поле не важно, ГЛАВНОЕ НЕ ЗАБУДЬ ИЗМЕНИТ В OrderRepository способ заполнения OrderListItems

        public Guid OrderId { get; set; }
        public Status Status { get; set; }
    }
}
