using System;
using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithValidations.Models
{
    public class Survey
    {
        // Name Field
        [Required(ErrorMessage="Please provide a name.")]
        [NoZNames]
        [MinLength(2, ErrorMessage="Too short.")]
        [MaxLength(50, ErrorMessage="Too long.")]
        [Display(Name="Name: ")]
        public string Name { get; set;}
        // Location Field
        [Required]
        [Display(Name="Dojo Location: ")]
        public string Location { get; set;}
        // Language Field
        [Required]
        [Display(Name="Favorite Language: ")]
        public string Language { get; set;}
        // Comments Field
        [MaxLength(20, ErrorMessage="Too long; did not read.")]
        [Display(Name="Comments (optional): ")]
        public string Comments { get; set;}
        // Email Field
        [EmailAddress]
        [Display(Name="Email Address: ")]
        public string Email { get; set; }

        [PastDate]
        [DataType(DataType.Date)]
        [Display(Name="Birthday: ")]
        public DateTime Birthday { get; set; }

        // Password
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string Password { get; set; }

        // Confirm Password
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password: ")]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
        // Created-At Field
        public DateTime CreatedAt { get; set; } = DateTime.Now;
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
    public class NoZNamesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((string)value).ToLower()[0] == 'z')
                return new ValidationResult("No names that start with Z allowed!");
            return ValidationResult.Success;
        }
    }


}