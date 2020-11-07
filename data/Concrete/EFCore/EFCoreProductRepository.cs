using System.Collections.Generic;
using System.Linq;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete.EFCore
{
    public class EFCoreProductRepository : GenericRepository<Product, BarberContext>, IProductRepository
    {
         public Product GetByIdWithCategories(int id)
        {
            using (var context = new BarberContext())
            {
                return context.Products
                        .Where(i => i.id == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new BarberContext())
            {
                var products = context.Products.Where(i=>i.isApproved).AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.url == category));
                }

                return products.Count();
            }
        }

        public Product GetProductDetails(string url)
        {
            using (var context = new BarberContext())
            {
                return context.Products
                            .Where(i => i.url == url)
                            .Include(i => i.ProductCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new BarberContext())
            {
                var products = context.Products
                    .Where(i=>i.isApproved)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.url == category));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new BarberContext())
            {
                var product = context.Products
                                   .Include(i => i.ProductCategories)
                                   .FirstOrDefault(i => i.id == entity.id);

                if (product != null)
                {
                    product.name = entity.name;
                    product.description = entity.description;
                    product.imageUrl = entity.imageUrl;
                    product.price = entity.price;
                    product.url = entity.url;
                    product.isApproved = entity.isApproved;
                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        CategoryId = catid,
                        ProductId = entity.id
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        
         public List<Product> GetProductBySearch(string search)
        {
            using (var context = new BarberContext()){
                return context.Products.Where(i=>(i.isApproved && ( i.name.ToLower().Contains(search)|| i.description.ToLower().Contains(search)))).ToList();
            }
        }

    }
}