using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity;
[Index(nameof(Email), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required, EmailAddress]
    public string Password { get; set; }
     [Required]
    public string Phone { get; set; }
    public string Email { get; set; }
    [Required]
    public Role Role { get; set; } = Role.Customer;
}
