using Microsoft.AspNetCore.Mvc;

namespace SucroseRestaurant.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
