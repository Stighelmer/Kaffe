using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class ProductIndexViewModel
    {
        public ProductIndexViewModel()
        {
            Products = new List<ProductListViewModel>();
        }

        public class ProductListViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
            public string Details { get; set; }
            public decimal Price { get; set; }
        }

        public List<ProductListViewModel> Products { get; set; }

        public string Search { get; set; }
        public string CurrentSort { get; set; }
    }
}