using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HardCodeTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICategoryApiRepository _repositoryCategory;
        private readonly IProductApiRepository _repositoryProduct;

        public ProductController(ICategoryApiRepository repositoryCategory, IProductApiRepository repositoryProduct)
        {
            _repositoryCategory = repositoryCategory;
            _repositoryProduct = repositoryProduct;
        }

        //GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_repositoryProduct.GetAll());
        }

        //GET api/product/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(string id)
        {
            var result = _repositoryProduct.GetById(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        //GET api/product/getbycategoryid/{id}
        [HttpGet("/api/product/getbycategoryid/{id}")]
        public ActionResult<Product> GetByCategoryId(string id)
        {
            var category = _repositoryCategory.GetById(id);

            if (category is null)
                return NotFound();

            var categoryProducts = _repositoryProduct.GetAll()
                                                     .Where(s => s.CategoryId == id);

            return Ok(categoryProducts);
        }

        //POST api/product/filter
        [HttpPost("/api/product/filter")]
        public ActionResult<Product> Filter(string categoryId, AdditionalField currentFilter)
        {
            var category = _repositoryCategory.GetById(categoryId);

            if (category is null)
                return NotFound();

            var categoryProducts = _repositoryProduct.Filter(currentFilter).Where(s=>s.CategoryId == categoryId);

            return Ok(categoryProducts);
        }

        //POST api/product
        //[Authorize]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid is false) return BadRequest(ModelState);

            var category = _repositoryCategory.GetById(product.CategoryId);
            if(category is null)
                throw new ArgumentNullException($"Category with id: {product.CategoryId} doesn't exist");

            _repositoryProduct.Create(product);
            return Ok(product);
        }

        //DELETE api/product/{id}
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid is false) return BadRequest(ModelState);

            if (_repositoryProduct.GetById(id) is null)
                throw new ArgumentNullException($"Product with id: {id} doesn't exist");

            _repositoryProduct.Delete(id);
            return NoContent();
        }
    }
}
