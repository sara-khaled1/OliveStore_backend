using System.ComponentModel.DataAnnotations;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

    }
}