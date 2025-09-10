using Microsoft.AspNetCore.Mvc;
using NooraAppMVC.Data;
using NooraAppMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace NooraAppMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDBContext _dbContext;

        public ProductsController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Index
        public IActionResult Index()
        {
            IEnumerable<Product> products = _dbContext.Products.ToList();
            return View(products);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null) return NotFound();

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}