﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NooraAppMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength (100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal (18,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string StockQuantity { get; set; }
    }
}
