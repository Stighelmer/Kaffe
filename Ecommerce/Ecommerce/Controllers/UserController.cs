using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ecommerce;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        private readonly ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public UserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager =>
            _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public ActionResult Index()
        {
            var model = new UserIndexViewModel();

            model.UserList.AddRange(_context.Users.Select(x => new UserIndexViewModel.UserListViewModel
            {
                UserId = x.Id,
                Email = x.Email
            }));
            foreach (var item in model.UserList)
            {
                item.UserRoles = UserManager.GetRoles(item.UserId).SingleOrDefault();
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var model = new UserViewModel();
            var user = UserManager.FindById(id);

            model.UserId = user.Id;
            model.Email = user.Email;
            model.UserRoles = UserManager.GetRoles(user.Id).SingleOrDefault();
            model.UserDropDownList = new List<SelectListItem>();

            foreach (var item in _context.Roles)
            {
                model.UserDropDownList.Add(new SelectListItem {Value = item.Name, Text = item.Name});
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserManager.FindById(model.UserId);
            user.Id = model.UserId;
            user.Email = model.Email;
            UserManager.RemoveFromRole(user.Id, model.UserRoles);
            UserManager.AddToRole(user.Id, model.UserDropDownHolder);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var model = new UserViewModel();
            var user = UserManager.FindById(id);
            model.Email = user.Email;
            model.UserRoles = UserManager.GetRoles(user.Id).SingleOrDefault();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = UserManager.FindById(id);
            var userRoles = UserManager.GetRoles(id);

            if (userRoles.Any())
            {
                foreach (var item in userRoles.ToList())
                {
                    await UserManager.RemoveFromRoleAsync(user.Id, item);
                }
            }

            await UserManager.DeleteAsync(user);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}