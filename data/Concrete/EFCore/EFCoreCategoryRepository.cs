using System.Linq;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete.EFCore
{
    public class EFCoreCategoryRepository :GenericRepository<Category, BarberContext>, ICategoryRepository
    {
           public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context = new BarberContext())
            {
                var cmd = "delete from ProductCategory where ProductId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context = new BarberContext())
            {
                return context.Categories
                        .Where(i => i.id == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault();
            }
        }
    }
}