namespace Admin.Models.Categories
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetCategories();
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategory(Category category);
    }
}
