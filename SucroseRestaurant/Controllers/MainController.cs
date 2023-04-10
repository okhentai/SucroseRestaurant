using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
