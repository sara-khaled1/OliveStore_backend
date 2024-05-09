using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.DTO
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { set; get; }

    }
    public class OrderCreateDto
    {
        public Guid AddressId { get; set; }
        public double TotalPrice { set; get; }
    }
    public class CheckoutDto
    {
        public Guid AddressId { get; set; }
        public List<Items>? Items { get; set; }
    }
    public class Items
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}