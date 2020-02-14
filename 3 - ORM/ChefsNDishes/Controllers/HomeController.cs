using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
    
        // here we can "inject" our context service into the constructor
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(c => c.CreatedDishes).ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("addchef")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Chefs.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }
        
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(d => d.Creator).ToList();
            ViewBag.AllDishes = AllDishes;
            return View("Dishes");
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(c => c.CreatedDishes).ToList();
            ViewBag.AllChefs = AllChefs;
            return View("NewDish");
        }
        
        [HttpPost("adddish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.Chefs.Include(c => c.CreatedDishes).ToList();
                ViewBag.AllChefs = AllChefs;
                return View("NewDish");
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
