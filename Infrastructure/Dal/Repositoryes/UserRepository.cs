using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositoryes
{
    public class UserRepository : IUserRepository
    {
        private readonly ArtGalleryDbContext _dbContext;

        public UserRepository(ArtGalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public User Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public ICollection<Order> GetUserOrders(Guid userId)
        {
            return _dbContext.Orders.Where(o => o.UserId == userId).ToList();
        }

        public bool Delete(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
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