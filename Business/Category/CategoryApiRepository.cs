using Data;
using Models;

namespace Business
{
    public class CategoryApiRepository : ICategoryApiRepository
    {
        private readonly IMongoRepository<Category> _context;
        public CategoryApiRepository(IMongoRepository<Category> context)
        {
            _context = context;
        }

        public async void Create(Category item)
        {
            await _context.InsertOneAsync(item);
        }

        public async void Delete(string id)
        {
            await _context.DeleteByIdAsync(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.AsQueryable();
        }

        public Category GetById(string id)
        {
            return _context.FindById(id);
        }
    }
}
