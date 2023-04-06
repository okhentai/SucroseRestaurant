using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
