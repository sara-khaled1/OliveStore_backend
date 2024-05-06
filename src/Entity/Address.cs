using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
public class Address
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Zip_code { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}
