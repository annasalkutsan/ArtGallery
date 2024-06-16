using Application.DTO.User;
using Domain.Entities;

namespace Application.Interfaces;

public interface IOrderRepository:IRepository<Order>
{
    ICollection<Order> GetOrdersNotStarted();
    ICollection<Order> GetOrdersReady();
    ICollection<Order> GetOrdersInDevelopment();
    Task<(List<Order>, int)> GetPagedOrdersAsync(int pageNumber, int pageSize);
}
