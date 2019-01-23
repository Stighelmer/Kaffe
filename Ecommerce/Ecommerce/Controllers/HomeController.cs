using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.AspNet.Identity;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Categories
        public ViewResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        [Authorize]
        public ViewResult New()
        {
            var viewModel = new CategoryFormViewModel();

            return View("CategoryForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
                return HttpNotFound();

            var viewModel = new CategoryFormViewModel(category);

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CategoryFormViewModel();

                return View("CategoryForm", viewModel);
            }

            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.Id == category.Id);
                categoryInDb.Name = category.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}