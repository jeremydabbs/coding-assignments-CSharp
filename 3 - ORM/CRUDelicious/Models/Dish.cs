using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required(ErrorMessage="Dish name is required.")]
        [MinLength(3,ErrorMessage="Dish name must be at least three characters.")]
        [Display(Name="Dish: ")]
        public string Name { get; set; }
        [Required(ErrorMessage="Chef is required.")]
        [MinLength(3,ErrorMessage="Chef's name must be at least three characters.")]
        [Display(Name="Chef's Name: ")]
        public string Chef { get; set; }
        [Required(ErrorMessage="Tastiness score is required.")]
        [Range(1,5)]
        [Display(Name="Tastiness (1-5): ")]
        public int Tastiness { get; set; }
        [Required(ErrorMessage="Calorie count is required.")]
        [Display(Name="# of Calories: ")]
        [Range(0,Int32.MaxValue)]
        public int Calories { get; set; }
        [Display(Name="Description: ")]
        [MinLength(3,ErrorMessage="Description must be at least three characters.")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}