using Application.DTO.Order.Pag;
using Application.Interfaces;
using Application.Paginations;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Dal.EntityFramework;


namespace Infrastructure.Dal.Repositoryes
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ArtGalleryDbContext _dbContext; // замените на ваш контекст данных

        public OrderRepository(ArtGalleryDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public Order GetById(Guid id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public ICollection<Order> GetOrdersNotStarted()
        {
            return _dbContext.Orders.Where(o => o.Status == EnumTypeStatus.NotStarted).ToList();
        }

        public ICollection<Order> GetOrdersReady()
        {
            return _dbContext.Orders.Where(o => o.Status == EnumTypeStatus.Ready).ToList();
        }

        public ICollection<Order> GetOrdersInDevelopment()
        {
            return _dbContext.Orders.Where(o => o.Status == EnumTypeStatus.InDevelopment).ToList();
        }

        /// <summary>
        ///     Новый метод для получения заказов с пагинацией  (x2 new)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public OrderListResponse GetPagedOrders(OrderListRequest request)
        {
            var quest = _dbContext.Orders.AsQueryable();

            //  Ты можешь сделать базовые проверки, как пример:

            if (request.OrderDate != null)
                quest = quest.Where(x => x.OrderDate == request.OrderDate);

            var orderList = quest.GetPaginationResponse<Order, OrderListResponse, OrderListItems>(request, x =>
            new OrderListItems
            {
                OrderId = x.Id,
                Status = x.Status,
            });

            return orderList;
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
    }
}
