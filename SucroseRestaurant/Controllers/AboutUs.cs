using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
