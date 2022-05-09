using Microsoft.EntityFrameworkCore;
using ShopApp2.DataAccess.Abstract;
using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp2.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopApp2Context>, IProductDal
    {
        public List<Product> GetProductsByCategory(string category, int page,int pageSize)
        {
            using (var context=new ShopApp2Context())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                             .Include(i => i.ProductCategories)
                             .ThenInclude(i => i.Category)
                             .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context=new ShopApp2Context())
            {
                return context.Products
                              .Where(i => i.Id == id)
                              .Include(i => i.ProductCategories)
                              .ThenInclude(i => i.Category)
                              .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopApp2Context())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                             .Include(i => i.ProductCategories)
                             .ThenInclude(i => i.Category)
                             .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Count();
            }
        }

        public Product GetByIdWithCategories(int id)
        {
            using (var context=new ShopApp2Context())
            {
                return context.Products
                       .Where(i => i.Id == id)
                       .Include(i => i.ProductCategories)
                       .ThenInclude(i => i.Category)
                       .FirstOrDefault();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context=new ShopApp2Context())
            {
                var product = context.Products
                                   .Include(i=>i.ProductCategories)
                                   .FirstOrDefault(i => i.Id == entity.Id);
                if (product!=null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;

                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        CategoryId=catid,
                        ProductId=entity.Id

                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}
