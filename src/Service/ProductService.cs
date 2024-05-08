using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Server;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public IEnumerable<ProductReadDto> FindAll()
    {
        var products = _productRepository.FindAll();
        var productRead = products.Select(_mapper.Map<ProductReadDto>);
        return productRead;
    }

    public ProductReadDto? FindOne(Guid id)
    {
        Product? product = _productRepository.FindOne(id);
        ProductReadDto? productRead = _mapper.Map<ProductReadDto>(product);
        return productRead;
    }
    public ProductReadDto? FindByCategory(Guid categoryId)
    {
        Product? product = _productRepository.FindByCategory(categoryId);
        ProductReadDto? productRead = _mapper.Map<ProductReadDto>(product);
        return productRead;
    }

    public ProductReadDto CreateOne(ProductCreateDto product)
    {
        var newProduct = _mapper.Map<Product>(product);
        var createdProduct = _productRepository.CreateOne(newProduct);
        var productRead = _mapper.Map<ProductReadDto>(createdProduct);
        return productRead;
    }

    public ProductReadDto? UpdateOne(Guid id, ProductReadDto updatedReadProduct)
    {
        Product? updatedProduct = _productRepository.FindOne(id);
        if (updatedProduct is not null)
        {
            updatedProduct.Name = updatedReadProduct.Name;
            updatedProduct.Price = updatedReadProduct.Price;
            updatedProduct.Quantity = updatedReadProduct.Quantity;
            updatedProduct.CategoryId = updatedReadProduct.CategoryId;
            updatedProduct.Image = updatedReadProduct.Image;
            updatedProduct.Description = updatedReadProduct.Description;

            var productAllInfo = _productRepository.UpdateOne(updatedProduct);
            var productRead = _mapper.Map<ProductReadDto>(productAllInfo);
            return productRead;
        }
        else return null;
    }
    public bool DeleteOne(Guid id)
    {
        return _productRepository.DeleteOne(id);
    }
}