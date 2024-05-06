using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Database;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repository;

public class ProductRepository : IProductRepository
{
    private DbSet<Product> _products { get; set; }
    private DatabaseContext _databaseContext;
    public ProductRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _products = databaseContext.Products;
    }

    public IEnumerable<Product> FindAll()
    {
        return _products;
    }

    public Product? FindOne(Guid id)
    {
        Product? product = _products.FirstOrDefault(product => product.Id == id);
        if (product is null)
        {
            return null;
        }
        return product;
    }
    public Product? FindByCategory(Guid categoryId)
    {
        Product? product = _products.FirstOrDefault(product => product.CategoryId == categoryId);
        if (product is null)
        {
            return null;
        }
        return product;
    }

    public Product CreateOne(Product product)
    {
        _products.Add(product);
        _databaseContext.SaveChanges();
        return product;
    }

    public Product UpdateOne(Product updatedProduct)
    {
        _products.Update(updatedProduct);
        _databaseContext.SaveChanges();
        return updatedProduct;
    }
    public void UpdateQuantity(Product updatedProduct)
    {
        _products.Update(updatedProduct);
        _databaseContext.SaveChanges();
    }
    public bool DeleteOne(Guid id)
    {
        Product? foundProduct = FindOne(id);
        if (foundProduct is null) return false;
        _products.Remove(foundProduct);
        _databaseContext.SaveChanges();
        return true;
    }
}
