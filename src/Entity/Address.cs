using System.ComponentModel.DataAnnotations;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
public class Address
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Street { get; set; }
    public int Zip_code { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}
