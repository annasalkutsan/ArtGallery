using Application.DTO.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public OrderResponse GetById(Guid id)
        {
            var order = _orderRepository.GetById(id);
            var response = _mapper.Map<OrderResponse>(order);
            return response;
        }

        public List<OrderResponse> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var response = _mapper.Map<List<OrderResponse>>(orders);
            return response;
        }

        public async Task<OrderResponse> CreateAsync(OrderCreateRequest request)
        {
            var order = _mapper.Map<Order>(request);
            var createdOrder = _orderRepository.Create(order);
            await _orderRepository.SaveChanges();
            var response = _mapper.Map<OrderResponse>(createdOrder);
            return response;
        }

        public async Task<OrderResponse> Update(OrderUpdateRequest request)
        {
             /*var order = _mapper.Map<Order>(request);
            var updatedOrder = _orderRepository.Update(order);
            await _orderRepository.SaveChanges();
            var response = _mapper.Map<OrderResponse>(updatedOrder);
            return response;*/
            
            
            
            // Получаем существующий заказ по Id
            var existingOrder = _orderRepository.GetById(request.Id);
    
            if (existingOrder == null)
            {
                // Если заказ не найден, возвращаем null или обрабатываем ошибку
                return null;
            }
    
            // Обновляем только те свойства, которые должны измениться
            existingOrder.OrderDate = request.OrderDate;
            existingOrder.Status = request.Status;

            // Сохраняем изменения
            _orderRepository.Update(existingOrder);
            await _orderRepository.SaveChanges();

            // Маппируем обновленный заказ на OrderResponse и возвращаем его
            var response = _mapper.Map<OrderResponse>(existingOrder);
            return response;
        }

        public bool Delete(Guid id)
        {
            return _orderRepository.Delete(id);
        }

        public ICollection<OrderResponse> GetOrdersNotStarted()
        {
            var orders = _orderRepository.GetOrdersNotStarted();
            return _mapper.Map<ICollection<OrderResponse>>(orders);
        }

        public ICollection<OrderResponse> GetOrdersReady()
        {
            var orders = _orderRepository.GetOrdersReady();
            return _mapper.Map<ICollection<OrderResponse>>(orders);
        }

        public ICollection<OrderResponse> GetOrdersInDevelopment()
        {
            var orders = _orderRepository.GetOrdersInDevelopment();
            return _mapper.Map<ICollection<OrderResponse>>(orders);
        }
        // Новый метод для получения заказов с пагинацией
        public async Task<PaginatedOrderResponse> GetPagedOrdersAsync(int pageNumber, int pageSize)
        {
            var (orders, totalOrders) = await _orderRepository.GetPagedOrdersAsync(pageNumber, pageSize);
            var response = _mapper.Map<List<OrderResponse>>(orders);

            return new PaginatedOrderResponse
            {
                Orders = response,
                TotalOrders = totalOrders,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }