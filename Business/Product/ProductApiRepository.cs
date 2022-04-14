using Data;
using Models;

namespace Business
{
    public class ProductApiRepository : IProductApiRepository
    {
        private readonly IMongoRepository<Product> _contextProduct;
        public ProductApiRepository(IMongoRepository<Product> context)
        {
            _contextProduct = context;
        }
        public async void Create(Product item)
        {
            await _contextProduct.InsertOneAsync(item);
        }

        public async void Delete(string id)
        {
            await _contextProduct.DeleteByIdAsync(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _contextProduct.AsQueryable();
        }

        public Product GetById(string id)
        {
            return _contextProduct.FindById(id);
        }

        public IEnumerable<Product> Filter(AdditionalField field)
        {
            return _contextProduct.FilterBy(s => s.AdditionalFields.Contains(field));
        }
    }
}
