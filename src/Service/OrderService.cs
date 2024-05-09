using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IOrderRepository orderReposiroty, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderReposiroty;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }
        public IEnumerable<OrderReadDto> FindAll()
        {
            var orders = _orderRepository.FindAll();
            var ordersRead = orders.Select(_mapper.Map<OrderReadDto>);
            return ordersRead;
        }
        public OrderReadDto? FindOne(Guid orderId)
        {
            Order? order = _orderRepository.FindOne(orderId);
            OrderReadDto? orderRead = _mapper.Map<OrderReadDto>(order);
            return orderRead;
        }
        public OrderReadDto CreateOne(OrderCreateDto order)
        {
            var newProduct = _mapper.Map<Order>(order);
            var createdOrder = _orderRepository.CreateOne(newProduct);
            var orderRead = _mapper.Map<OrderReadDto>(createdOrder);
            return orderRead;
        }
        public OrderReadDto Checkout(CheckoutDto checkoutList, string userId)
        {
            double TotalPrice = 0;
            var order = new Order();
            order.AddressId = checkoutList.AddressId;
            order.UserId = new Guid(userId);
            order.Status = Enums.Status.Pending;
            var createdOrder = _orderRepository.CreateOne(order);
            var orderRead = _mapper.Map<OrderReadDto>(createdOrder);
            foreach (var orderCheckout in checkoutList.Items!)
            {
                var product = _productRepository.FindOne(orderCheckout.ProductId);
                if (product is null) continue;
                if (product.Quantity >= orderCheckout.Quantity)
                {
                    product.Quantity -= orderCheckout.Quantity;
                    _productRepository.UpdateQuantity(product);
                    var orderItem = new OrderItem();
                    orderItem.ProductId = product.Id;
                    orderItem.OrderId = order.Id;
                    orderItem.Quantity = orderCheckout.Quantity;
                    orderItem.UnitPrice = (product.Price * orderCheckout.Quantity);
                    _orderItemRepository.CreateOne(orderItem);
                    TotalPrice += orderItem.UnitPrice;
                }
            }
            order.TotalPrice = TotalPrice;
            return orderRead;
        }

        public OrderReadDto? UpdateOne(Guid id, Order newOrder)
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

        public bool DeleteOne(Guid id)
        {
            return _orderRepository.DeleteOne(id);
        }

    }
}