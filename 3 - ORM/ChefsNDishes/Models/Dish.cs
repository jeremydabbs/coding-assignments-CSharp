using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        
        [Required(ErrorMessage="Dish name is required.")]
        [MinLength(3,ErrorMessage="Dish name must be at least three characters.")]
        [Display(Name="Dish: ")]
        public string Name { get; set; }
        
        [Required(ErrorMessage="Tastiness score is required.")]
        [Range(1,5,ErrorMessage="Tastiness must from 1-5.")]
        [Display(Name="Tastiness (1-5): ")]
        public int Tastiness { get; set; }
        
        [Required(ErrorMessage="Calorie count is required.")]
        [Display(Name="# of Calories: ")]
        [Range(0,Int32.MaxValue,ErrorMessage="Calories must be greaterthan 0.")]
        public int Calories { get; set; }
        
        [Required(ErrorMessage="Description is required.")]
        [MinLength(3,ErrorMessage="Description must be at least three characters.")]
        [Display(Name="Description: ")]
        public string Description { get; set; }

        //Foreign Key
        [Display(Name="Name of Chef: ")]
        public int ChefId { get; set; }

        //Navigational Property
        public Chef Creator { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}