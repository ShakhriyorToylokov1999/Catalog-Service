using Catalog_Service.Models;

namespace Catalog_Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        
        IEnumerable<Category> AddCategory(Category category);
        
        void UpdateCategory(int id, Category category);
        
        void DeleteCategory(int id);
        
    }
}
