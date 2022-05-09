using Microsoft.AspNetCore.Mvc;
using ShopApp2.Business.Abstract;
using ShopApp2.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory=RouteData.Values["category"]?.ToString(),
                Categories=_categoryService.GetAll()
            });
        }
    }
}
