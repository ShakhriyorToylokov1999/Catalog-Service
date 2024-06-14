using Catalog_Service.Models;

namespace Catalog_Service.Interfaces
{
    public interface IItemsService
    {
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetItems(int categoryId, int page = 1, int pageSize = 10);
        IEnumerable<Item> AddItem(Item item);
        void UpdateItem(int id, Item item);
        void DeleteItem(int id);
        void DeleteItemsByCategoryId(int categoryId);
    }
}
