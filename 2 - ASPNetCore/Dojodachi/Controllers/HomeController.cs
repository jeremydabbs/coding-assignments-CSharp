using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Fullness") == null)
            {
            HttpContext.Session.SetInt32("Fullness", 20);
            HttpContext.Session.SetInt32("Happiness", 20);
            HttpContext.Session.SetInt32("Energy", 50);
            HttpContext.Session.SetInt32("Meals", 3);
            HttpContext.Session.SetString("Message", "A happy Domodachi!");
            HttpContext.Session.SetString("Complete", "False");
            HttpContext.Session.SetString("Deceased", "False");
            }
            //If energy, fullness, and happiness are all raised to over 100, you win! a restart button should be displayed.
            if(HttpContext.Session.GetInt32("Fullness") >= 100 && HttpContext.Session.GetInt32("Happiness") >= 100 && HttpContext.Session.GetInt32("Energy") >= 100)
            {
                HttpContext.Session.SetString("Complete", "True");
                HttpContext.Session.SetString("Message", "YOU WIN!!!!!");
            }
            //If fullness or happiness ever drop to 0, you lose, and a restart button should be displayed.
            else if(HttpContext.Session.GetInt32("Fullness") <= 0 || HttpContext.Session.GetInt32("Happiness") <= 0)
            {
                HttpContext.Session.SetString("Complete", "True");
                HttpContext.Session.SetString("Deceased", "True");
                HttpContext.Session.SetString("Message", "Domodachi has passed away...");
            }


            // ***TempData is an alternative to ViewBag***
            // 
            // TempData["Fullness"] = HttpContext.Session.GetInt32("Fullness");
            // TempData["Happiness"] = HttpContext.Session.GetInt32("Happiness");
            // TempData["Energy"] = HttpContext.Session.GetInt32("Energy");
            // TempData["Meals"] = HttpContext.Session.GetInt32("Meals");
            // TempData["Message"] = HttpContext.Session.GetString("Message");
            // TempData["Complete"] = HttpContext.Session.GetString("Complete");
            //
            ViewBag.fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.message = HttpContext.Session.GetString("Message");
            ViewBag.complete = HttpContext.Session.GetString("Complete");
            ViewBag.deceased = HttpContext.Session.GetString("Deceased");


            return View();
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            if((int)HttpContext.Session.GetInt32("Meals") == 0)
            {
                HttpContext.Session.SetString("Message", "Uh oh! You have no more meals.");
                return RedirectToAction("Index");
            }
            else
            {
            //Feeding costs 1 meal
            int? meals = HttpContext.Session.GetInt32("Meals");
            meals -= 1;
            HttpContext.Session.SetInt32("Meals", (int)meals);
            //Feeding gains random amount of happiness between 5 and 10. Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
            Random interaction = new Random();
            int like = interaction.Next(1, 101);
            if(like > 25)
            {
                int? fullness = HttpContext.Session.GetInt32("Fullness");
                Random random = new Random();
                fullness += random.Next(5, 11);
                HttpContext.Session.SetInt32("Fullness", (int)fullness);
                HttpContext.Session.SetString("Message", "YUMMY!!!");
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetString("Message", "ICK!!! Domodachi didn't like that.");
                return RedirectToAction("Index");
            }
            }
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            if((int)HttpContext.Session.GetInt32("Energy") < 5)
            {
                HttpContext.Session.SetString("Message", "Oh no! Domodachi doesn't have enough energy to play.");
                return RedirectToAction("Index");
            }
            else
            {
            //Playing with your Dojodachi costs 5 energy
            int? energy = HttpContext.Session.GetInt32("Energy");
            energy -= 5;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            //Playing gains random amount of happiness between 5 and 10. Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
            Random interaction = new Random();
            int like = interaction.Next(1, 101);
            if(like > 25)
            {
                int? happiness = HttpContext.Session.GetInt32("Happiness");
                Random random = new Random();
                happiness += random.Next(5, 11);
                HttpContext.Session.SetInt32("Happiness", (int)happiness);
                HttpContext.Session.SetString("Message", "Playtime is fun!");
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetString("Message", "Domodachi isn't feeling playful right now.");
                return RedirectToAction("Index");
            }
            }
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            if((int)HttpContext.Session.GetInt32("Energy") < 5)
            {
                HttpContext.Session.SetString("Message", "Oh no! Domodachi doesn't have enough energy to work.");
                return RedirectToAction("Index");
            }
            else
            {
            //Working costs 5 energy
            int? energy = HttpContext.Session.GetInt32("Energy");
            energy -= 5;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            //Working earns between 1 and 3 meals
            int? meals = HttpContext.Session.GetInt32("Meals");
            Random random = new Random();
            meals += random.Next(1, 4);
            HttpContext.Session.SetInt32("Meals", (int)meals);
            HttpContext.Session.SetString("Message", "Domodachi is a good worker!");
            return RedirectToAction("Index");
            }
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            //Sleeping increases energy by 15
            int? energy = HttpContext.Session.GetInt32("Energy");
            energy += 15;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            //Sleeping decreases fullness and happiness each by 5
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            fullness -= 5;
            HttpContext.Session.SetInt32("Fullness", (int)fullness);
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            HttpContext.Session.SetInt32("Happiness", (int)happiness);
            HttpContext.Session.SetString("Message", "Zzzzzzzzzzzzzzzzzzzzzzz");
            return RedirectToAction("Index");
        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
