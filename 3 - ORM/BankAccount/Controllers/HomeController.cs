using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using BankAccount.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BankAccount.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email","Email already exists.");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> hash = new PasswordHasher<User>();
                    register.Password = hash.HashPassword(register,register.Password);
                    dbContext.Users.Add(register);
                    dbContext.SaveChanges();
                    //return RedirectToAction("Login");
                    HttpContext.Session.SetInt32("UserId",register.UserId);
                    return Redirect($"/bank/{register.UserId}");
                }
            }
            else
            {
                return View("Index");
            }
        }
        
        [HttpPost("signin")]
        public IActionResult SignIn(LoginUser log)
        {
            if(ModelState.IsValid)
            {
                User check = dbContext.Users.FirstOrDefault(u => u.Email == log.LoginEmail);
                if(check == null)
                {
                    ModelState.AddModelError("LoginEmail","Invalid Email/Password");
                    return View("Login");
                }
                else
                {
                    PasswordHasher<LoginUser> compare = new PasswordHasher<LoginUser>();
                    var result = compare.VerifyHashedPassword(log,check.Password,log.LoginPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LoginEmail","Invalid Email/Password");
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId",check.UserId);
                        return Redirect($"/bank/{check.UserId}");
                    }
                }
            }
            else
            {
                return View("Login");
            }
        }
        



        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        
        //Sets up the Special Characters requirement for the Password field on User.cs
        public class PasswordSpecialCharsAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\p{P}\p{S}]).{8,32}$";

                if (!Regex.IsMatch((string)value, patternPassword))
                    return new ValidationResult("Password must be at least 8 characters, no more than 32 characters, and must include at least one upper case letter, one lower case letter, one numeric digit, and one special character.");
                return ValidationResult.Success;
            }
        }
        
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
