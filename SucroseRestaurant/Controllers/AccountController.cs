using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
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
