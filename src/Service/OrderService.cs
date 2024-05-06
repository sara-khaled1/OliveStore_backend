using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        private IProductRepository _productRepository;
        private IMapper _mapper;
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
        public OrderReadDto Checkout(List<CheckoutDto> checkoutList)//? what we return OR void?
        {
            var order = new Order();
            order.UserId = Guid.NewGuid();
            order.AddressId = Guid.NewGuid();
            order.Status = "pending";
            order.OrderDate = DateTime.Now;
            order.TotalPrice = 100;
            var createdOrder = _orderRepository.CreateOne(order);//?? how will fill other fields?

            foreach (var orderCheckout in checkoutList)
            {
                var product = _productRepository.FindOne(orderCheckout.ProductId);
                if (product is null) continue;

                if (product.Quantity >= orderCheckout.Quantity)
                {
                    product.Quantity -= orderCheckout.Quantity;
                    _productRepository.UpdateQuantity(product); //! does this update the product? yes.
                    var orderItem = new OrderItem();
                    orderItem.ProductId = product.Id;
                    orderItem.OrderId = order.Id;
                    orderItem.Quantity = orderCheckout.Quantity;
                    orderItem.UnitPrice = (product.Price * orderCheckout.Quantity);
                    _orderItemRepository.CreateOne(orderItem);
                }

            }
            var orderRead = _mapper.Map<OrderReadDto>(createdOrder);
            return orderRead;

            /*
            [
  {
    "quantity": 4,
    "productId": "b033b1bd-86a3-4cd7-9972-1fcd1cabfe29"
  },
{
    "quantity": 3,
    "productId": "0b698e9d-5d2d-4112-8717-cf8143dd6d7d"
  }
]

            */
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