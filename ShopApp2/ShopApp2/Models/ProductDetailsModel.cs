using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
