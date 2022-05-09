using Microsoft.AspNetCore.Mvc;
using ShopApp2.Business.Abstract;
using ShopApp2.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        
        public HomeController(IProductService productService)
        {
            _productService = productService;
            
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}
