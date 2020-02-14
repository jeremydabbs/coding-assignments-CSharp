using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    [Route("wedding")]
    public class WeddingController : Controller
    {
        private HomeContext dbContext;
        public WeddingController(HomeContext context)
        {
            dbContext = context;
        }
        private User UserWithRsvps() //This is the LoggedIn() method in the LoginReg project
        {
            return dbContext.Users.Include(u => u.PlannedWeddings).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }

        public IActionResult Index()
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            else
            {
                List<Wedding> AllWeddings = dbContext.Weddings.Include(w => w.GuestList).ThenInclude(r => r.Guest).Include(w => w.Planner).OrderBy(w => w.Date).Where(w => w.Date > DateTime.Now).ToList();
                ViewBag.User = userInDb;
                return View(AllWeddings);
            }
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            else
            {
                ViewBag.User = userInDb;
                return View();
            }
        }

        [HttpPost("addwedding")]
        public IActionResult AddWedding(Wedding newWedding)
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            // if(ModelState.IsValid)
            // {
            //     dbContext.Weddings.Add(newWedding);
            //     dbContext.SaveChanges();
            //     return Redirect($"/wedding/{newWedding.WeddingId}");
            // }
            // else
            // {
            //     ViewBag.User = userInDb;
            //     return View("New");
            // }
            if(ModelState.IsValid)
            {
                if(userInDb.PlannedWeddings.Any(w => w.Date == newWedding.Date))
                {
                    ModelState.AddModelError("Date", "Time Conflict.");
                    ViewBag.User = userInDb;
                    return View("New");
                }
                else
                {
                    dbContext.Weddings.Add(newWedding);
                    dbContext.SaveChanges();
                    return Redirect($"/wedding/{newWedding.WeddingId}");
                }
            }
            ViewBag.User = userInDb;
			return View("New");
        }

        [HttpGet("{weddingId}")]
        public IActionResult Wedding(int weddingId)
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            else
            {
                Wedding show = dbContext.Weddings.Include(w => w.GuestList).ThenInclude(rsvp => rsvp.Guest).Include(w => w.Planner).FirstOrDefault(w => w.WeddingId == weddingId);
                ViewBag.User = userInDb;
                return View("Wedding", show);
            }
        }

        [HttpGet("rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            else
            {
                Rsvp newRsvp = new Rsvp()
                {
                    WeddingId = weddingId,
                    UserId = (int)HttpContext.Session.GetInt32("UserId")
                };
                dbContext.Rsvps.Add(newRsvp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet("unrsvp/{weddingId}")]
        public IActionResult UnRSVP(int weddingId)
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            else
            {
                Rsvp RsvpToDelete = dbContext.Rsvps.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == userInDb.UserId );
                dbContext.Rsvps.Remove(RsvpToDelete);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet("response/{weddingId}/{userId}/{status}")]
        public IActionResult Reservation(int weddingId, int userId, string status)
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            if(status == "rsvp")
            {
                Rsvp going = new Rsvp();
                going.UserId = userId;
                going.WeddingId = weddingId;
                dbContext.Rsvps.Add(going);
                dbContext.SaveChanges();
            }
            else if(status == "unrsvp")
            {
                Rsvp backout = dbContext.Rsvps.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == userId);
                dbContext.Rsvps.Remove(backout);
                dbContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
            return RedirectToAction("Index");
        }



        [HttpGet("delete")]
        public IActionResult DeleteWedding(int weddingId)
        {
            User userInDb = UserWithRsvps();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            Wedding weddingToDelete = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            dbContext.Weddings.Remove(weddingToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
            // else
            // {
            //     if(ModelState.IsValid)
            //     {
            //         Wedding weddingToDelete = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            //         dbContext.Weddings.Remove(weddingToDelete);
            //         dbContext.SaveChanges();
            //         return RedirectToAction("Index");
            //     }
            //     else
            //     {
            //         List<Wedding> AllWeddings = dbContext.Weddings.Include(w => w.GuestList).OrderBy(w => w.Date).ToList();
            //         ViewBag.AllWeddings = AllWeddings;
            //         ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            //         return View("Index");
            //     }
            // }
        }
        

    }
}