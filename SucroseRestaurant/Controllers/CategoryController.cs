using Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult List()
        {
            return View(_categoryRepository.GetCategories());
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("List");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            return View("UpdateCategory", _categoryRepository.GetCategory(id));
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                return RedirectToAction("List");
            }
            return View(category);
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(_categoryRepository.GetCategory(id));
            return RedirectToAction("List");
        }
    }
}
