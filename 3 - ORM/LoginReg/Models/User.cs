using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using static LoginReg.Controllers.HomeController;

namespace LoginReg.Models
{
    public class User
    {
        //User ID//
        [Key]
        public int UserId { get; set; }

        //First Name Field//
        [Required(ErrorMessage="First name is required.")]
        [MinLength(2,ErrorMessage="First name must be at least two characters.")]
        [Display(Name="First Name: ")]
        public string FirstName { get; set; }
        
        //Last Name Field//
        [Required(ErrorMessage="Last name is required.")]
        [MinLength(3,ErrorMessage="Last name must be at least three characters.")]
        [Display(Name="Last Name: ")]
        public string LastName { get; set; }
        
        //Email Field//
        [Required(ErrorMessage="Email address is required.")]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string Email { get; set; }
        
        //Password Field//
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8,ErrorMessage="Password must be at least eight characters.")]
        [DataType(DataType.Password)]
        [PasswordSpecialChars] //Custom Validation
        [Display(Name="Password: ")]
        public string Password { get; set; }
        
        //Confirm Password Field//
        [Required(ErrorMessage="Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="Passwords do not match.")]
        [Display(Name="Confirm Password: ")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        
        //Created At Field//
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        //Updated At Field//
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }


    ////Custom Validations
    
    //Sets up the Special Characters requirement for the Password field on User.cs
        public class PasswordSpecialCharsAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                //string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,32}$";
                //string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#\$%\^\&*\)\(+=._-]).{8,32}$";
                string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\p{P}\p{S}]).{8,32}$";

                if ((string)value == null)
                {
                    return new ValidationResult("Password must be at least 8 characters, no more than 32 characters, and must include at least one upper case letter, one lower case letter, one numeric digit, and one special character.");
                }
                else if (!Regex.IsMatch((string)value, patternPassword))
                {
                    return new ValidationResult("Password must be at least 8 characters, no more than 32 characters, and must include at least one upper case letter, one lower case letter, one numeric digit, and one special character.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
}