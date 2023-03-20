using Microsoft.AspNetCore.Mvc;

namespace SucroseRestaurant.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
