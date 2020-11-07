using System.Collections.Generic;
using entity;

namespace data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category, int page, int pageSize);

        Product GetProductDetails(string url);

        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
        List<Product> GetProductBySearch(string search);
    }
}