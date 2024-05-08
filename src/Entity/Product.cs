using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
public class Product
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public int Quantity { get; set; }
    public string Description { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}
