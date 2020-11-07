using System.Collections.Generic;
using entity;
namespace business.Abstract
{
    public interface IProductService
    {
         
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        List<Product> GetProductsByCategory(string category, int page, int pageSize);

        Product GetProductDetails(string url);

        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
        List<Product> GetProductBySearch(string search);
    }
}