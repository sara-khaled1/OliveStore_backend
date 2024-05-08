using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Password { get; set; }
    public int Phone { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    public Role Role { get; set; } = Role.Customer;
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<Address> Addresses { get; set; }

}
