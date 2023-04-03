using Microsoft.AspNetCore.Mvc;
using SucroseRestaurant.Models;
using System.Diagnostics;

namespace SucroseRestaurant.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}