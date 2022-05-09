using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp2.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        Category GetByIdWithProducts(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
