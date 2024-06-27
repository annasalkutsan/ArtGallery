using Application.Paginations;

namespace Application.DTO.Painting.Pag
{
    /// <summary>
    ///     new
    /// </summary>
    public class PaintingListRequest : IPaginationRequest
    {
        //  поиск по название либо описанию 
        public string? Search { get; set; }

        public PageRequest? Page { get; set; }
    }
}
