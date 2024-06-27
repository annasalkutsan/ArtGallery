using Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository: IRepository<User>
{
    ICollection<Order> GetUserOrders(Guid userId);
}