using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction
{
    public interface IOrderService
    {
        public IEnumerable<OrderReadDto> FindAll();
        public OrderReadDto? FindOne(Guid orderId);
        public OrderReadDto CreateOne(OrderCreateDto order);
        public OrderReadDto Checkout(List<CheckoutDto> checkoutList, string userId);
        public OrderReadDto? UpdateOne(Guid id, Order order);
        public bool DeleteOne(Guid id);
    }
}