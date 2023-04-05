namespace SucroseRestaurant.Models.Foods
{
    public interface IFoodRepository
    {
        Food GetFood(int id);
        IEnumerable<Food> GetAll();
        Food AddFood(Food food);
        Food UpdateFood(Food food);
        Food DeleteFood(Food food);
    }
}
