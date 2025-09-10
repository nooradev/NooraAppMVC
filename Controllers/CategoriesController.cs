using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NooraAppMVC.Data;
using NooraAppMVC.Models;

namespace NooraAppMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _dbContext;
        public CategoriesController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
   

        // Index
        public IActionResult Index()
        {
            IEnumerable<Category> category = _dbContext.Categories.ToList();
            return View(category);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}