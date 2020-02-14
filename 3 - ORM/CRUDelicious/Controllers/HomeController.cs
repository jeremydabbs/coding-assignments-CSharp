using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;
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
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            ViewBag.AllDishes = AllDishes;
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("adddish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("{dishId}")]
        public IActionResult Get(int dishId)
        {
            ViewBag.DishInfo = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View("Dish");
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish DishInfo = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View("Edit",DishInfo);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult UpdateDish(Dish update, int dishId)
        {
            if(ModelState.IsValid)
            {
                Dish RetrievedDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
                RetrievedDish.Name = update.Name;
                RetrievedDish.Chef = update.Chef;
                RetrievedDish.Calories = update.Calories;
                RetrievedDish.Tastiness = update.Tastiness;
                RetrievedDish.Description = update.Description;
                RetrievedDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit",update);
            }
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish RetrievedDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishId);
            dbContext.Dishes.Remove(RetrievedDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
