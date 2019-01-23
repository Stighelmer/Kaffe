using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Product name required.")]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Required(ErrorMessage = "Category required.")]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Details { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}