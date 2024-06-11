using Application.Interfaces;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositoryes;

public class OrderRepository : IOrderRepository
{
    private readonly ArtGalleryDbContext _dbContext; // замените на ваш контекст данных

    public OrderRepository(ArtGalleryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Order GetById(Guid id)
    {
        return _dbContext.Orders.FirstOrDefault(o => o.Id == id);
    }

    public List<Order> GetAll()
    {
        return _dbContext.Orders.ToList();
    }

    public Order Create(Order entity)
    {
        _dbContext.Orders.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public Order Update(Order entity)
    {
        _dbContext.Orders.Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Delete(Guid id)
    {
        var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public ICollection<Order> GetOrdersNotStarted()
    {
        return _dbContext.Orders.Where(o => o.Status == Status.NotStarted).ToList();
    }

    public ICollection<Order> GetOrdersReady()
    {
        return _dbContext.Orders.Where(o => o.Status == Status.Ready).ToList();
    }

    public ICollection<Order> GetOrdersInDevelopment()
    {
        return _dbContext.Orders.Where(o => o.Status == Status.InDevelopment).ToList();
    }
}