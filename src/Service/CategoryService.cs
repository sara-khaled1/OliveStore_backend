using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
namespace sda_onsite_2_csharp_backend_teamwork.src.Service;
public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper)
    {
        _categoryRepository = CategoryRepository;
        _mapper = mapper;
    }
    public IEnumerable<CategoryReadDto> FindAll()
    {
        var categories = _categoryRepository.FindAll();
        var categoriesRead = categories.Select(_mapper.Map<CategoryReadDto>);
        return categoriesRead;
    }
    public CategoryReadDto? FindOne(Guid id)
    {
        Category? category = _categoryRepository.FindOne(id);
        CategoryReadDto? categoryRead = _mapper.Map<CategoryReadDto>(category);
        return categoryRead;
    }
    public CategoryReadDto CreateOne(CategoryCreateDto category)
    {
        var newCategory=_mapper.Map<Category>(category);
        var createdCatgory = _categoryRepository.CreateOne(newCategory);
        var categoryRead = _mapper.Map<CategoryReadDto>(createdCatgory);
        return categoryRead;
    }
    
    public CategoryReadDto? UpdateOne(Guid categoryId, Category newCategory)
    {
        Category? updatedCategory = _categoryRepository.FindOne(categoryId);
        if (updatedCategory is not null)
        {
            updatedCategory.Name = newCategory.Name;
            updatedCategory.Description = newCategory.Description;
            var categoryUpdated = _categoryRepository.UpdateOne(updatedCategory);
            var updatedCategoryRead = _mapper.Map<CategoryReadDto>(categoryUpdated);
            return updatedCategoryRead;
        }
        else return null;
    }

    public bool DeleteOne(Guid id)
    {
        return _categoryRepository.DeleteOne(id);
    }
}