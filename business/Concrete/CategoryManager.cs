using System.Collections.Generic;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryrepository;
        public CategoryManager( ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }
        public void Create(Category entity)
        {
            _categoryrepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryrepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
           return _categoryrepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryrepository.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryrepository.Update(entity);
        }
        public Category GetByIdWithProducts(int id){
            return _categoryrepository.GetByIdWithProducts(id);
        }

        public void DeleteFromCategory(int categoryId, int productId)
        {
            _categoryrepository.DeleteFromCategory(categoryId,productId);
        }
    }
}