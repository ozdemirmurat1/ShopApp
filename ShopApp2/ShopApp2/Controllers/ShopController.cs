using Microsoft.AspNetCore.Mvc;
using ShopApp2.Business.Abstract;
using ShopApp2.Entities;
using ShopApp2.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product==null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product=product,
                Categories=product.ProductCategories.Select(i=>i.Category).ToList()
            });
        }

        // products/telefon?page=1
        public IActionResult List(string category,int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems=_productService.GetCountByCategory(category), // kategoriye ait ürün sayısını getirir.
                    CurrentPage=page,
                    ItemsPerPage=pageSize,
                    CurrentCategory=category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            }); 
        }
        

    }
}
