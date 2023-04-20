using Admin.Data;
using Admin.Models.Categories;

namespace Admin.Models.Foods
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext appDbContext;

        public FoodRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Food AddFood(Food food)
        {
            appDbContext.Foods.Add(food);
            appDbContext.SaveChanges();
            return food;
        }

        public Food DeleteFood(int id)
        {
            Food? food = appDbContext.Foods.Find(id);
            if (food != null)
            {
                appDbContext.Foods.Remove(food);
                appDbContext.SaveChanges();

            }
            else
            {
                throw new Exception("Food not found");
            }
            return food;
        }

        public IEnumerable<Food> GetAll()
        {
            appDbContext.SaveChanges();
            return appDbContext.Foods;
        }

        public Food GetFood(int id)
        {
            return appDbContext.Foods.Find(id);
        }

        public IEnumerable<Food> GetFoodByCategory(int categoryId = 0)
        {
           if (categoryId == 0)
            {
                appDbContext.SaveChanges();
                return appDbContext.Foods;
            }
            else
            {
                appDbContext.SaveChanges();
                return appDbContext.Foods.Where(f => f.CategoryId == categoryId);
            }
        }

        public Food UpdateFood(Food food)
        {
            appDbContext.Foods.Update(food);
            appDbContext.SaveChanges();
            return food;
        }
    }
}
