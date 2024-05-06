using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstraction
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryReadDto> FindAll();
        public CategoryReadDto? FindOne(Guid id);
        public CategoryCreateDto CreateOne(Category category);
        public CategoryReadDto? UpdateOne(Guid categoryId, Category newCategory);
        public bool DeleteOne(Guid id);

    }
}