using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // Message someMessage = new Message()
            // {
            //     Messages = "Chase ball of string eat plants, meow, and throw up because I ate plants going to catch the red dot today going to catch the red dot today. I could pee on this if I had the energy. Chew iPad power cord steal the warm chair right after you get up for purr for no reason leave hair everywhere, decide to want nothing to do with my owner today."
            // };
            string anotherMessage = new string("Chase ball of string.");
            return View("Index",anotherMessage);
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

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] someNumbers = new int[]
            {
                1,2,3
            };
            return View(someNumbers);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            User user1 = new User()
            {
                FirstName = "Moose",
                LastName = "Phillips"
            };
            User user2 = new User()
            {
                FirstName = "Sarah",
                LastName = "Midgey"
            };
            User user3 = new User()
            {
                FirstName = "Jerry",
                LastName = "Swiller"
            };
            User user4 = new User()
            {
                FirstName = "Rene Ricky",
                LastName = "Ricardo"
            };

            List<User> viewModel = new List<User>()
            {
                user1, user2, user3, user4
            };
            return View(viewModel);
        }

        [HttpGet("user")]
        public IActionResult ShowUser()
        {
            User user1 = new User()
            {
                FirstName = "Moose",
                LastName = "Phillips"
            };
            return View("User", user1);
        }


    }
}
