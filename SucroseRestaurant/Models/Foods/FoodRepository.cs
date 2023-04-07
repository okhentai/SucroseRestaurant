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

        public Food DeleteFood(Food food)
        {
            appDbContext?.Foods.Remove(food);
            appDbContext?.SaveChanges();
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

        public Food UpdateFood(Food food)
        {
            appDbContext.Foods.Update(food);
            appDbContext.SaveChanges();
            return food;
        }
    }
}
