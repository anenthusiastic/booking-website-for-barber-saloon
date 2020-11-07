using System.Collections.Generic;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productrepository;
        public ProductManager(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }
        public void Create(Product entity)
        {
            _productrepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productrepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productrepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productrepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productrepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productrepository.GetCountByCategory(category);
        }

        public Product GetProductDetails(string url)
        {
            return _productrepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productrepository.GetProductsByCategory(category,page,pageSize);
        }

        public void Update(Product entity)
        {
            _productrepository.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productrepository.Update(entity,categoryIds);
        }

        public List<Product> GetProductBySearch(string search){
            return _productrepository.GetProductBySearch(search);
        }
    }
}