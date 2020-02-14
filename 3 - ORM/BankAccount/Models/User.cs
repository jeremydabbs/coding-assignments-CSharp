using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BankAccount.Controllers.HomeController;

namespace BankAccount.Models
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
        [PasswordSpecialChars] //Custom Validation - Set up in the HomeController
        [Display(Name="Password: ")]
        public string Password { get; set; }
        
        //Confirm Password Field//
        [Required(ErrorMessage="Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="Passwords do not match.")]
        [Display(Name="Confirm Password: ")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        ////Navigational property
        public List<Transaction> MyTransactions { get; set; }
        
        //Created At Field//
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        //Updated At Field//
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}