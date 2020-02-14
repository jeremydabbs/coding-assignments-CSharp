using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class LoginUser
    {
        //Login Email Field//
        [Required(ErrorMessage="Email address is required.")]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string LoginEmail { get; set; }
        
        //Login Password Field//
        [Required(ErrorMessage="Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string LoginPassword { get; set; }
    }
}