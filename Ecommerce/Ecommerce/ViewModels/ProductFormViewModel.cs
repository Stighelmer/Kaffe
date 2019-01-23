using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class ProductFormViewModel
    {
        public ProductFormViewModel()
        {
            Id = 0;
        }

        public ProductFormViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            CategoryId = product.CategoryId;
            Details = product.Details;
            Price = product.Price;
            DateAdded = product.DateAdded;
        }

        public IEnumerable<Category> Categories { get; set; }

        public int? Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        public decimal? Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; } = DateTime.Today;

        public string Title => Id != 0 ? "Edit Product" : "New Product";
    }
}