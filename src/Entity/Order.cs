using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { set; get; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

    }
}