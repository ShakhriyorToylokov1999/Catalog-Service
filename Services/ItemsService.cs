using Catalog_Service.Interfaces;
using Catalog_Service.Models;

namespace Catalog_Service.Services
{
    public class ItemsService : IItemsService
    {
        private readonly List<Item> _items;
        public ItemsService()
        {
            _items = new List<Item>();
        }

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
        public IEnumerable<Item> GetItems(int categoryId, int page = 1, int pageSize = 10)
        {
            var filteredItems = _items.Where(item => item.CategoryId == categoryId)
                                     .Skip((page - 1) * pageSize)
                                     .Take(pageSize);
            return filteredItems.ToList();
        }

        public IEnumerable<Item> AddItem(Item item)
        {
            _items.Add(item);
            return _items;
        }

        public void UpdateItem(int id, Item item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.CategoryId = item.CategoryId;
            }
        }
        public void DeleteItem(int id)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                _items.Remove(existingItem);
            }
        }
        public void DeleteItemsByCategoryId(int categoryId)
        {
            _items.RemoveAll(i => i.CategoryId == categoryId);
        }
    }
}
