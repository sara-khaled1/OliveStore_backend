using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service
{
    public class OrderService : IOrderService
    {

        private IOrderRepository _orderRepository;
        private IMapper _mapper;
        public OrderService(IOrderRepository orderReposiroty, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderReposiroty;
        }
        public IEnumerable<OrderReadDto> FindAll()
        {
            var orders = _orderRepository.FindAll();
            var ordersRead = orders.Select(_mapper.Map<OrderReadDto>);
            return ordersRead;
        }
        public OrderReadDto? FindOne(string orderId)
        {

            Order? order = _orderRepository.FindOne(orderId);
            OrderReadDto? orderRead = _mapper.Map<OrderReadDto>(order);
            return orderRead;
        }
        public OrderReadDto CreateOne(Order order)
        {
            var createdOrder = _orderRepository.CreateOne(order);
            var orderRead = _mapper.Map<OrderReadDto>(createdOrder);
            return orderRead;
        }
        public OrderReadDto? UpdateOne(string id, Order newOrder)
        {

            Order? updatedOrder = _orderRepository.FindOne(id);
            if (updatedOrder is not null)
            {
                updatedOrder.Status = newOrder.Status;

                var updatedOrderAllInfo = _orderRepository.UpdateOne(updatedOrder);
                var updatedOrderRead = _mapper.Map<OrderReadDto>(updatedOrderAllInfo);
                return updatedOrderRead;
            }
            else return null;
        }

        public bool DeleteOne(string id)
        {
            return _orderRepository.DeleteOne(id);
        }

    }
}