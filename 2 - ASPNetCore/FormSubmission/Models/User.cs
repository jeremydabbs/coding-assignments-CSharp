using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Age: ")]
        public int Age { get; set; }
        [Required]
        // [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        [MinLength(6, ErrorMessage="Password must be at least six characters long.")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}