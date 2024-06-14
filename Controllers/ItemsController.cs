using Catalog_Service.Interfaces;
using Catalog_Service.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemService;

        public ItemsController(IItemsService itemService)
        {
            _itemService = itemService;
        }
        // GET: api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }
        // GET: api/items?categoryId={categoryId}&page={page}&pageSize={pageSize}
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems(int categoryId, int page = 1, int pageSize = 10)
        {
            var items = _itemService.GetItems(categoryId, page, pageSize);
            return Ok(items);
        }

        // POST: api/items
        [HttpPost]
        public ActionResult<Item> AddItem(Item item)
        {
            var addedItem = _itemService.AddItem(item);
            return CreatedAtAction(nameof(GetItems), addedItem);
        }


        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Item item)
        {
            _itemService.UpdateItem(id, item);
            return NoContent();
        }

        // DELETE: api/catalog/items/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            _itemService.DeleteItem(id);
            return NoContent();
        }

    }
}
