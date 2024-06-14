using Catalog_Service.Interfaces;
using Catalog_Service.Models;

namespace Catalog_Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories;
        private readonly IItemsService _itemService;

        public CategoryService(IItemsService itemService)
        {
            _categories = new List<Category>();
            _itemService = itemService;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        

        public IEnumerable<Category> AddCategory(Category category)
        {
            _categories.Add(category);
            return _categories;
        }


        public void UpdateCategory(int id, Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
            }
        }

        public void DeleteCategory(int id)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                _categories.Remove(existingCategory);
                _itemService.DeleteItemsByCategoryId(id);
            }
        }


    }
}
