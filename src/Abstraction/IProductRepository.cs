using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction
{
    public interface IProductRepository
    {
        public IEnumerable<Product> FindAll();
        public Product? FindOne(Guid id);
        public Product? FindByCategory(Guid categoryId);
        public Product CreateOne(Product product);
        public Product UpdateOne(Product product);
        public void UpdateQuantity(Product updatedProduct);
        public bool DeleteOne(Guid id);

    }
}