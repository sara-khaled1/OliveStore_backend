using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryReadDto> FindAll();
        public CategoryReadDto? FindOne(Guid id);
        public CategoryReadDto CreateOne(CategoryCreateDto category);
        public CategoryReadDto? UpdateOne(Guid categoryId, Category newCategory);
        public bool DeleteOne(Guid id);

    }
}