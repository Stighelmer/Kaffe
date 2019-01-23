using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class CategoryFormViewModel
    {
        public CategoryFormViewModel()
        {
            Id = 0;
        }

        public CategoryFormViewModel(Category category)
        {
            Name = category.Name;
        }

        public int? Id { get; set; }

        public string Name { get; set; }

        public string Title => Id != 0 ? "Edit Category" : "New Category";
    }
}