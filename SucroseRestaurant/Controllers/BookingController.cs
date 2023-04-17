using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
