﻿namespace Admin.Models.Foods
{
    public interface IFoodRepository
    {
        Food GetFood(int id);
        IEnumerable<Food> GetAll();
        IEnumerable<Food> GetFoodByCategory(int categoryId);
        Food AddFood(Food food);
        Food UpdateFood(Food food);
        Food DeleteFood(int id);
    }
}
