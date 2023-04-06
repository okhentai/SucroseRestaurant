using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        public IActionResult ListAdmin()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
