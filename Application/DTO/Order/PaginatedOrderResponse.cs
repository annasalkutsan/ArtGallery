namespace Application.DTO.User;

public class PaginatedOrderResponse
{
    public List<OrderResponse> Orders { get; set; }
    public int TotalOrders { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}