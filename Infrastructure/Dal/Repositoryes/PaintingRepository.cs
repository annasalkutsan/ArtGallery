using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositoryes;

public class PaintingRepository : IPaintingRepository
{
    private readonly ArtGalleryDbContext _dbContext; // замените на ваш контекст данных

    public PaintingRepository(ArtGalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Painting GetById(Guid id)
    {
        return _dbContext.Paintings.FirstOrDefault(p => p.Id == id);
    }

    public List<Painting> GetAll()
    {
        return _dbContext.Paintings.ToList();
    }

    public Painting Create(Painting entity)
    {
        _dbContext.Paintings.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public Painting Update(Painting entity)
    {
        /* _dbContext.Paintings.Update(entity);
        _dbContext.SaveChanges();
        return entity;*/
        
        var existingPainting = _dbContext.Paintings.Find(entity.Id);
        if (existingPainting == null)
        {
            throw new Exception("Painting not found");
        }

        existingPainting.Title = entity.Title;
        existingPainting.Description = entity.Description;
        existingPainting.Price = entity.Price;

        // Ensure ImagePath is not null or empty
        if (!string.IsNullOrEmpty(entity.ImagePath))
        {
            existingPainting.ImagePath = entity.ImagePath;
        }

        _dbContext.Paintings.Update(existingPainting);
        _dbContext.SaveChanges();
        return existingPainting;
    }

    public bool Delete(Guid id)
    {
        var painting = _dbContext.Paintings.FirstOrDefault(p => p.Id == id);
        if (painting != null)
        {
            _dbContext.Paintings.Remove(painting);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public ICollection<Painting> GetPaintingsByAscendingPrice()
    {
        return _dbContext.Paintings.OrderBy(p => p.Price).ToList();
    }
}