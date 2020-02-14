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
    [Route("bank")]
        public class BankController : Controller
    {
        private HomeContext dbContext;
        public BankController(HomeContext context)
        {
            dbContext = context;
        }

        private User UserWithTransaction() //This is the LoggedIn() method in the LoginReg project
        {
            return dbContext.Users.Include(u => u.MyTransactions).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }

        [HttpGet("{userId}")]
        public IActionResult Index()
        {
            User userInDb = UserWithTransaction();
            if(userInDb == null)
            {
                return RedirectToAction("Logout","Home");
            }
            else
            {
                ViewBag.Transactions = userInDb.MyTransactions.OrderByDescending(t => t.CreatedAt).ToList();
                ViewBag.Balance = userInDb.MyTransactions.Sum(t => t.Amount);
                ViewBag.User = userInDb;
                return View();
            }
        }

        [HttpPost("process")]
        public IActionResult Process(Transaction newTran)
        {
            User userInDb = UserWithTransaction();
            double balance = userInDb.MyTransactions.Sum(t => t.Amount);
            if(ModelState.IsValid)
            {
                if(balance + newTran.Amount < 0)
                {
                    ModelState.AddModelError("Amount", "Insufficient funds for withdrawal.");
                    //Because we have ViewBag info displaying on the Index page, ViewBag info has to be resubmitted.
                    ViewBag.Transactions = userInDb.MyTransactions.OrderByDescending(t => t.CreatedAt).ToList();
                    ViewBag.Balance = balance;
                    ViewBag.User = userInDb;
                    return View("Index");
                }
                else
                {
                    dbContext.Transactions.Add(newTran);
                    dbContext.SaveChanges();
                    return Redirect($"/bank/{userInDb.UserId}");
                }
            }
            else
            {
                //Because we have ViewBag info displaying on the Index page, ViewBag info has to be resubmitted.
                ViewBag.Transactions = userInDb.MyTransactions.OrderByDescending(t => t.CreatedAt).ToList();
                ViewBag.Balance = balance;
                ViewBag.User = userInDb;
                return View("Index");
            }
        }

    }
}