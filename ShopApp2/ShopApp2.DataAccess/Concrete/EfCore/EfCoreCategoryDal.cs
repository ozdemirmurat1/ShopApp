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
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, ShopApp2Context>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context=new ShopApp2Context())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context=new ShopApp2Context())
            {
                return context.Categories
                       .Where(i => i.Id == id)
                       .Include(i => i.ProductCategories)
                       .ThenInclude(i => i.Product)
                       .FirstOrDefault();
            }
        }
    }
}
