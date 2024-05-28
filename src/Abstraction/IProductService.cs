using sda_onsite_2_csharp_backend_teamwork.src.DTO;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction
{
    public interface IProductService
    {
        public IEnumerable<ProductReadDto> FindAll( string? searchBy);
        public ProductReadDto? FindOne(Guid id);
        public ProductReadDto? FindByCategory(Guid categoryId);
        public ProductReadDto CreateOne(ProductCreateDto product);
        public ProductReadDto? UpdateOne(Guid id, ProductReadDto updatedReadProduct);
        public bool DeleteOne(Guid id);
    }
}