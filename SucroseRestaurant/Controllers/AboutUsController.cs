using Microsoft.AspNetCore.Mvc;

namespace SucroseRestaurant.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
