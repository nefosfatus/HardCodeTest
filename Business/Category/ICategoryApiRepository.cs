namespace Business.Category
{
    internal interface ICategoryApiRepository
    {
        bool SaveChanges();

        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Create(Category item);
        void Delete(Category item);
    }
}
