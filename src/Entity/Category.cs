using System.ComponentModel.DataAnnotations;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entity
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}