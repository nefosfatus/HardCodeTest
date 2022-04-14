using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HardCodeTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApiRepository _repository;

        public CategoryController(ICategoryApiRepository repository)
        {
            _repository = repository;
        }

        //GET api/category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        //GET api/category/{id}
        [HttpGet("{id}")]
        public ActionResult<Category> GetById(string id)
        {
            var result = _repository.GetById(id);

            if(result is null)
                return NotFound();

            return Ok(result);
        }

        //POST api/category
        //[Authorize]
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid is false) return BadRequest(ModelState);

            _repository.Create(category);
            return Ok(category);
        }

        //DELETE api/category/{id}
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid is false) return BadRequest(ModelState);

            if (_repository.GetById(id) is null)
                throw new ArgumentNullException($"Category with id: {id} doesn't exist");

            _repository.Delete(id);
            return NoContent();
        }

    }
}
