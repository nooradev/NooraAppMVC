using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NooraAppMVC.Models;

namespace NooraAppMVC.Data
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
           public DbSet<Category> Categories { get; set; }
           public DbSet<Employee> Employees { get; set; }
           public DbSet<Product> Products { get; set; }

    }
   
}
