using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
