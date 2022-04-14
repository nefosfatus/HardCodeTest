using Models;

namespace Business
{
    public interface IProductApiRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(string id);
        void Create(Product item);
        void Delete(string id);
        IEnumerable<Product> Filter(AdditionalField field);
    }
}
