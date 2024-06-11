using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositoryes;

public class AuthorRepository : IAuthorRepository
{
    private readonly ArtGalleryDbContext _dbContext; // замените на ваш контекст данных

    public AuthorRepository(ArtGalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Author GetById(Guid id)
    {
        return _dbContext.Authors.FirstOrDefault(a => a.Id == id);
    }

    public List<Author> GetAll()
    {
        return _dbContext.Authors.ToList();
    }

    public Author Create(Author entity)
    {
        _dbContext.Authors.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public Author Update(Author entity)
    {
        _dbContext.Authors.Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Delete(Guid id)
    {
        var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public ICollection<Painting> GetAuthorPaintings(Guid authorId)
    {
        return _dbContext.Paintings.Where(p => p.AuthorId == authorId).ToList();
    }
}