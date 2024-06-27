using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositoryes
{
    public class ImageRepository : IImageRepository
    {
        private readonly ArtGalleryDbContext _dbContext; // замените на ваш контекст данных

        public ImageRepository(ArtGalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Image Create(Image entity)
        {
            _dbContext.Images.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Image Update(Image entity)
        {
            _dbContext.Images.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Image GetById(Guid id)
        {
            return _dbContext.Images.FirstOrDefault(i => i.Id == id);
        }

        public List<Image> GetAll()
        {
            return _dbContext.Images.ToList();
        }

        public bool Delete(Guid id)
        {
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == id);
            if (image != null)
            {
                _dbContext.Images.Remove(image);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}