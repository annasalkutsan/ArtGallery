using Application.Paginations;

namespace Application.DTO.Order.Pag
{
    public class OrderListResponse : IPaginationResponse<OrderListItems>
    {
        public ICollection<OrderListItems> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
