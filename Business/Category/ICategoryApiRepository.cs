using Models;

namespace Business
{
    public interface ICategoryApiRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(string id);
        void Create(Category item);
        void Delete(string id);
    }
}
