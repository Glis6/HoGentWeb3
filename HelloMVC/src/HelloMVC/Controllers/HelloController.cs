using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Greeting = (DateTime.Now.Hour <= 12 ? "Good morning" : "Good afternoon");
            return View();
        }
        public IActionResult About(int id=0)
        {
            return Content($"Hello from about {id}");
        }
    }
}
