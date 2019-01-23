using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string UserRoles { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string UserDropDownHolder { get; set; }
        public List<SelectListItem> UserDropDownList { get; set; }
    }
}