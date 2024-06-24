using Application.DTO.Painting.Pag;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPaintingRepository : IRepository<Painting>
    {
        PaintingListResponse GetPagedPainting(PaintingListRequest request);
    }
}