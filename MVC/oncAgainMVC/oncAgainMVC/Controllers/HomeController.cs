using Microsoft.AspNetCore.Mvc;
using oncAgainMVC.Models;
using System.Diagnostics;

namespace oncAgainMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string myname { get; set; } = "kareena";
      

        public IActionResult Index()
        {
            ViewData["name"]= myname;
             var myObj = new demoModel { id = 1, name = "spiderman", password=1234,url="www.youtube.com",phone="9898224565"};
            var details = Details();
            ViewData["obj"]=myObj;
            ViewBag.obj2 = myObj;
            ViewBag.details = details;
            
            return View(myObj);
        }

        [HttpPost]
        public string Index(demoModel demo)
        {
            string url_res = "";
            string name_res = "";
            if (string.IsNullOrEmpty(demo.url))
            {
                url_res = "you did not select any url";
            }
            else
            {
                url_res ="you selected url for " + demo.url + "!";
            }

            if (string.IsNullOrEmpty(demo.name))
            {
                name_res ="you did not select anything";
            }
            else
            {
                name_res= "you selected " +demo.name+ "!";
            }
            return name_res + "    " + url_res;
        }
        [NonAction] public string Details()
        {
            return "I am Called in another view";
        }
        public IActionResult IndexChild()
        {
            return View();
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