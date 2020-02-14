using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string name = "User";
            ViewBag.User = name;
            return View();
        }

        // The hidden process method below is from the Dojo Survey assignment in ASP MVC I.
        // [HttpPost("process")]
        // public IActionResult Process(string name, string location, string language, string comments)
        // {
        //     Survey newSurvey = new Survey();
        //     newSurvey.Name = name;
        //     newSurvey.Location = location;
        //     newSurvey.Language = language;
        //     newSurvey.Comments = comments;
        //     return View("Success",newSurvey);
        // }

        [HttpPost("survey")]
        public IActionResult Submission(Survey yourSurvey)
        {
            return View("Success",yourSurvey);
        }
    }
}