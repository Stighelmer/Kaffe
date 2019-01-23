using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Products
        public ViewResult Index()
        {
            var model = new ProductIndexViewModel();

            //var products = id != null ? 
            //    _context.Products.Include(p => p.Category).Where(c => c.CategoryId == id).ToList() : 
            //    _context.Products.Include(p => p.Category).ToList();

            var products = _context.Products.Include(p => p.Category).ToList();

            model.Products.AddRange(products.Select(p => new ProductIndexViewModel.ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Details = p.Details,
                Price = p.Price,
            }));

            model = Sort(model, model.CurrentSort);

            return View(model);
        }

        public ActionResult Search(string search, string sortBy)
        {
            var model = new ProductIndexViewModel
            {
                Search = search,
                CurrentSort = sortBy
            };

            var products = string.IsNullOrWhiteSpace(model.Search)
                ? _context.Products.Include(p => p.Category)
                : _context.Products.Include(p => p.Category)
                    .Where(p => p.Name.ToUpper().Contains(search.ToUpper()) ||
                                p.Category.Name.ToUpper().Contains(search.ToUpper()) ||
                                p.Details.ToUpper().Contains(search.ToUpper()));


            model.Products.AddRange(products.Select(p => new ProductIndexViewModel.ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Details = p.Details,
                Price = p.Price
            }));

            model = Sort(model, sortBy);

            return View(model);
        }

        [Authorize]
        public ViewResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new ProductFormViewModel
            {
                Categories = categories
            };

            return View("ProductForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel(product)
            {
                Categories = _context.Categories.ToList()
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel(product)
                {
                    Categories = _context.Categories.ToList()
                };

                return View("ProductForm", viewModel);
            }

            if (product.Id == 0)
            {
                product.DateAdded = DateTime.Today;
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.CategoryId = product.CategoryId;
                productInDb.Details = product.Details;
                productInDb.Price = product.Price;
                productInDb.DateAdded = product.DateAdded;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Single(p => p.Id == id);

            if (product == null)
            {
                return View("Index");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        private ProductIndexViewModel Sort(ProductIndexViewModel model, string sort)
        {
            switch (sort)
            {
                case "nameAsc":
                    model.Products = model.Products.OrderBy(p => p.Name).ToList();
                    break;
                case "nameDesc":
                    model.Products = model.Products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "priceAsc":
                    model.Products = model.Products.OrderBy(p => p.Price).ToList();
                    break;
                case "priceDesc":
                    model.Products = model.Products.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    model.Products = model.Products.OrderBy(p => p.Id).ToList();
                    break;
            }

            return model;
        }
    }
}