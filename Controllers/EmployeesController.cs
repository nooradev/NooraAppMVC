using Microsoft.AspNetCore.Mvc;
using NooraAppMVC.Data;
using NooraAppMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace NooraAppMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDBContext _dbContext;

        public EmployeesController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Index
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _dbContext.Employees.ToList();
            return View(employees);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Update(employee);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null) return NotFound();

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}