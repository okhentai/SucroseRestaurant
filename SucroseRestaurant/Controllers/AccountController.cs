using Microsoft.AspNetCore.Mvc;

namespace SucroseRestaurant.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Forgot()
        {
            return View();
        }
    }
}
