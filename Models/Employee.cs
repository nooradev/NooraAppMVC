using System.ComponentModel.DataAnnotations;

namespace NooraAppMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public double Salary { get; set; }
    }
}
