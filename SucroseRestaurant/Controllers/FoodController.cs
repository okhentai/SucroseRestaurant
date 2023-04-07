using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ListFood()
        {
            return View();
        }
        public IActionResult ListFoodAdmin()
        {
            return View();
        }
        public IActionResult DetailsFood()
        {
            return View();
        }
        public IActionResult AddFood()
        {
            return View();
        }
        public IActionResult UpdateFood()
        {
            return View();
        }
    }
}
