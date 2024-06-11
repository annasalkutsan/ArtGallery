using Application.DTO.User;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPaintingRepository:IRepository<Painting>
{
    ICollection<Painting> GetPaintingsByAscendingPrice();
}