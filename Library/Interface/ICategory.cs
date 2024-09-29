using Library.Models;

namespace Library.Interface;

public interface ICategory
{
    Task<bool> CreateCategory(Categories categories);
    Task<bool> UpdateCategory(Categories categories);
    Task<bool> DeleteCategory(Guid categoryId);
    Task<Categories> GetCategoryById(Guid categoryId);
    Task<IEnumerable<Categories>> GetAllCategories();
}