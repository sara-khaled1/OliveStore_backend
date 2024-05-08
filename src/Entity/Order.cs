using System.ComponentModel.DataAnnotations;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
public class Order
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid AddressId { get; set; }
    public Status Status { get; set; } = Status.Pending;

    public DateTime OrderDate { get; set; } = DateTime.Now;
    [Required]
    public double TotalPrice { set; get; }
    public IEnumerable<OrderItem>? OrderItems { get; set; }

}
