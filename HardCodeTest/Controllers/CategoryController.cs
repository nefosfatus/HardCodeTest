using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HardCodeTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMongoRepository<Category> _repository;

        public CategoryController(IMongoRepository<Category> peopleRepository)
        {
            _repository = peopleRepository;
        }

        [HttpPost()]
        public async Task<IActionResult> Add(string name)
        {
            var category = new Category()
            {
                Name = name
            };

            await _repository.InsertOneAsync(category);
            return Ok(category);
            
        }

        [HttpGet()]
        public IEnumerable<Category> GetCategories()
        {
            return _repository.AsQueryable();
        }
    }
}
