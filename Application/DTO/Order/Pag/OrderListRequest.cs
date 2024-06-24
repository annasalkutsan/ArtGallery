using Application.Paginations;

namespace Application.DTO.Order.Pag
{
    /// <summary>
    ///     new
    /// </summary>
    public class OrderListRequest : IPaginationRequest
    {
        //  Так же здесь можно задать дополнительные настройки поиска 
        //  Пример с датой
        public DateTime? OrderDate { get; set; }

        public PageRequest? Page { get; set; }
    }
}
