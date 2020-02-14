using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private static string CreateRandomPassword(int length = 14)  
        {  
            // Create a string of characters and numbers that are allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";  
            Random random = new Random();  
            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];  
            for (int i = 0; i < length; i++)  
            {  
                chars[i] = validChars[random.Next(0, validChars.Length)];  
            }  
            return new string(chars);  
        } 

        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("Counter", 1);
            ViewBag.count = 1;
            ViewBag.passcode = CreateRandomPassword();
            return View();
        }

        [HttpPost("generate")]
        public IActionResult Generate()
        {
            int? count = HttpContext.Session.GetInt32("Counter");
            count++;
            HttpContext.Session.SetInt32("Counter", (int)count);
            ViewBag.count = count;
            ViewBag.passcode = CreateRandomPassword();
            return View("Index");
        }


    }
}
