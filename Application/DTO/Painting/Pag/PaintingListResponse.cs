using Application.Paginations;

namespace Application.DTO.Painting.Pag
{
    public class PaintingListResponse : IPaginationResponse<PaintingListItems>
    {
        public ICollection<PaintingListItems> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
