using entity;

namespace data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
         void DeleteFromCategory(int categoryId, int productId);
         Category GetByIdWithProducts(int id);
    }
}