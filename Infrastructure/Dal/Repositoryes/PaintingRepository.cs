using Application.DTO.Painting.Pag;
using Application.Interfaces;
using Application.Paginations;
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

    /// <summary>
    ///     new
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public PaintingListResponse GetPagedPainting(PaintingListRequest request)
    {
        var quest = _dbContext.Paintings.AsQueryable();

        //  Ты можешь сделать базовые проверки как пример
        if (!string.IsNullOrEmpty(request.Search))
            quest = quest.Where(p => (p.Title + " " + p.Description).Contains(request.Search));

        var paintingList = quest.GetPaginationResponse<Painting, PaintingListResponse, PaintingListItems>(request, x => 
        new PaintingListItems 
        {
            Id = x.Id,
            Price = x.Price,
            Title = x.Title,
            ImagePath = x.ImagePath,
        });

        return paintingList;
    }
}