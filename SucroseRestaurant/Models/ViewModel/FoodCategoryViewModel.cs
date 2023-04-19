using Admin.Models.Categories;
using Admin.Models.Foods;

namespace Admin.Models.ViewModel
{
    public class FoodCategoryViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int CurrentCategoryId { get; set; }
    }
}
