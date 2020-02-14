using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        
        [Required(ErrorMessage="Chef's first name is required.")]
        [MinLength(2,ErrorMessage="Chef's name must be at least two characters.")]
        [Display(Name="First Name: ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Chef's last name is required.")]
        [MinLength(2,ErrorMessage="Chef's name must be at least two characters.")]
        [Display(Name="Last Name: ")]
        public string LastName { get; set; }

        [Required]
        [PastDate]
        [Over18]
        [Display(Name="Birthday: ")]
        public DateTime Birthday { get; set; }

        //Models can include methods. This is a method to calculate age to display on the Chefs page.
        public int Age()
        {
            int age = DateTime.Now.Year - Birthday.Year;
            if(DateTime.Now.Month < Birthday.Month)
            {
                if(DateTime.Now.Day < Birthday.Day)
                {
                age--;
                }
            }
            return age;
        }

        //Navigation Property
        public List<Dish> CreatedDishes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }


    public class PastDateAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime check;
            if(value is DateTime)
            {
                check = (DateTime)value;            
            }
            else
            {
                return new ValidationResult("Invalid DateTime");
            }
            if(check > DateTime.Now)
            {
                return new ValidationResult("Date must be in the past.");
            }
            return ValidationResult.Success;
        }
    }

    public class Over18Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime check;
            DateTime birthday = (DateTime)value;
	        //int ageInYears = ((((int.Parse(DateTime.Now.ToString("yyyyMMdd"))-(int.Parse(birthday.ToString("yyyyMMdd"))))/10000)));
            if(value is DateTime)
            {
                check = (DateTime)value;
                if(check > DateTime.Now.AddYears(-18))  
                {
                    return new ValidationResult("Chef must be older than 18.");
                }
                else
                {
                    return new ValidationResult("Chef must be older than 18.");
                }
            }
            else
            {
                return new ValidationResult("Invalid date provided.");
            }
            // if(ageInYears < 18)
            // {
            //     return new ValidationResult("Chef must be older than 18.");
            // }
            // return ValidationResult.Success;
        }
    }
}