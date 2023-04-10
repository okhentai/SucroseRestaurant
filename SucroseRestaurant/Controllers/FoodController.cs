using Admin.Models.Categories;
using Admin.Models.Foods;
using Admin.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodRepository foodRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FoodController(IFoodRepository foodRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.foodRepository = foodRepository;
            this.categoryRepository = categoryRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult List()
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
            return View("List", foodRepository.GetAll());
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            FoodViewModel model = new FoodViewModel();
            // model.GameList = new List<Game>();

            model.Categories = GetlistCategory();
            return View(model);
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
                    Stock = model.Stock,
                    PhotoPath = fileName
                };
                foodRepository.AddFood(food);
                return RedirectToAction("List");
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
            return View("List", foodRepository.GetAll());
        }
        //Hàm xử lý ảnh
        private void ProcessImage(IFormFile image, ref string fileName)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, "img");
            fileName = image.FileName;
            string filePath = Path.Combine(path, fileName);
            image.CopyTo(new FileStream(filePath, FileMode.Create));
        }
        //Hàm xử lý Category list hiển thị trong select
        protected List<SelectListItem> GetlistCategory()
        {
            var listCategoryName = new List<SelectListItem>();

            var listCateogry = categoryRepository.GetCategories();

            foreach (var game in listCateogry)
            {
                    listCategoryName.Add(
                    new SelectListItem
                    {
                        Text = game.Name,
                        Value = game.Id.ToString()
                    }
                );
            }

            return listCategoryName;
        }
    }
}
