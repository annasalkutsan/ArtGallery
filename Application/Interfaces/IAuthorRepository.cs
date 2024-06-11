using Application.DTO.User;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthorRepository:IRepository<Author>
{
    ICollection<Painting> GetAuthorPaintings(Guid authorId);
}