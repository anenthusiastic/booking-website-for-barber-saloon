using System.Collections.Generic;
using entity;
namespace business.Abstract
{
    public interface ICategoryService
    {
         
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProducts(int id);
        void DeleteFromCategory(int categoryId, int productId);
    }
}