using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
    
        // here we can "inject" our context service into the constructor
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            ViewBag.Products = dbContext.Products.ToList();
            return View();
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            ViewBag.Categories = dbContext.Categories.ToList();
            return View();
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product newProd)
        {
            if(ModelState.IsValid)
            {
                dbContext.Products.Add(newProd);
                dbContext.SaveChanges();
                return RedirectToAction("Products");
            }
            else
            {
                ViewBag.Products = dbContext.Products.ToList();
                return View("Products");
            }
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory(Category newCat)
        {
            if(ModelState.IsValid)
            {
                dbContext.Categories.Add(newCat);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                ViewBag.Categories = dbContext.Categories.ToList();
                return View("Categories");
            }
        }

        [HttpGet("product/{productId}")]
        public IActionResult Product(int productId)
        {
            ViewBag.Product = dbContext.Products.Include( p => p.AssocCategories).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == productId);
            ViewBag.NotOnProduct = dbContext.Categories.Include( c => c.AssocProducts).Where( c => c.AssocProducts.All(a => a.ProductId != productId)).ToList();
            return View();
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult Category(int categoryId)
        {
            ViewBag.Category = dbContext.Categories.Include( c => c.AssocProducts).ThenInclude(a => a.Product).FirstOrDefault(c => c.CategoryId == categoryId);
            ViewBag.NotOnCategory = dbContext.Products.Include( p => p.AssocCategories).Where( p => p.AssocCategories.All(a => a.CategoryId != categoryId)).ToList();
            return View();
        }
        
        [HttpPost("process/{path}")]
        public IActionResult Process(Association newAssoc, string path)
        {
            dbContext.Associations.Add(newAssoc);
            dbContext.SaveChanges();
            if(path == "category")
            {
                return Redirect($"/category/{newAssoc.CategoryId}");
            }
            else if(path == "product")
            {
                return Redirect($"/product/{newAssoc.ProductId}");
            }
            else
            {
                return RedirectToAction("Index");
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
