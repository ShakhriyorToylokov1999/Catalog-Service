using Catalog_Service.Interfaces;
using Catalog_Service.Models;
using Catalog_Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet("categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost("categories")]
        public ActionResult<Category> AddCategory(Category category)
        {
            var addedCategory = _categoryService.AddCategory(category);
            return CreatedAtAction(nameof(GetCategories), addedCategory);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("categories/{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            _categoryService.UpdateCategory(id, category);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("categories/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
