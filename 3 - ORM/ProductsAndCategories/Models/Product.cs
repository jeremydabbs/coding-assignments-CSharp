using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MinLength(3,ErrorMessage="Product name must be at least three characters.")]
        [Display(Name="Product Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Description: ")]
        public string Description { get; set; }

        [Required]
        [Range(0,double.MaxValue,ErrorMessage="Price is out of range.")]
        public double Price { get; set; }

        public List<Association> AssocCategories { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}