using Admin.Models.Foods;
using Admin.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IFoodRepository foodRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IFoodRepository foodRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.foodRepository = foodRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult ListFoodAdmin()
        {
            return View(foodRepository.GetAll());
        }

        public IActionResult DetailsFood()
        {
            return View();
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepository.DeleteFood(foodRepository.GetFood(id));
            return View("ListFoodAdmin", foodRepository.GetAll());
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if(model.PhotoPath != null)
                {
                    IFormFile image = model.PhotoPath;
                    ProcessImage(image, ref fileName);
                }
                Food food = new Food()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    category = model.category,
                    Stock = model.Stock,
                    PhotoPath = fileName
                };
                foodRepository.AddFood(food);
                return RedirectToAction("ListFoodAdmin");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateFood(int id)
        {
            return View(foodRepository.GetFood(id));
        }
        [HttpPost]
        public IActionResult UpdateFood(Food food)
        {
            foodRepository.UpdateFood(food);
            return View("ListFoodAdmin", foodRepository.GetAll());
        }
        //Hàm xử lý ảnh
        private void ProcessImage(IFormFile image, ref string fileName)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, "img");
            fileName = image.FileName;
            string filePath = Path.Combine(path, fileName);
            image.CopyTo(new FileStream(filePath, FileMode.Create));
        }
    }
}
