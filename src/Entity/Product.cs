using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
public class Product
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public IEnumerable<OrderItem>OrderItems { get; set; }


}
