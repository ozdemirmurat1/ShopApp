using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
