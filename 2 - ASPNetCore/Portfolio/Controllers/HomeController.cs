    using Microsoft.AspNetCore.Mvc;
    namespace Portfolio.Controllers     //be sure to use your own project's namespace!
    {
        public class HomeController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public ViewResult Index()
            {
                return View();
                //If we invoke View() with no arguments, ASP will look to serve a view file with the name of the action making the call. So if the name of the action is Index, ASP will go hunting for a file called Index.cshtml within your project's Views directory.
                //You may also invoke View("FileName"), with the name of a specific view file (minus .cshtml).
            }

            [HttpGet("projects")]
            public ViewResult Projects()
            {
                return View();
            }

            [HttpGet("contact")]
            public ViewResult Contact()
            {
                return View();
            }
        }
    }
