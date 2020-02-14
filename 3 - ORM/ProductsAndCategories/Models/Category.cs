using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3,ErrorMessage="Category name must be at least three characters.")]
        [MaxLength(40,ErrorMessage="Category name cannot be longer than 40 characters.")]
        [Display(Name="Category Name: ")]
        public string Name { get; set; }

        public List<Association> AssocProducts { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}