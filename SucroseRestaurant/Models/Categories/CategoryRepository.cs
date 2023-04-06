namespace Admin.Models.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Category AddCategory(Category category)
        {
            appDbContext.Categories.Add(category);
            appDbContext.SaveChanges();
            return category;
        }

        public Category DeleteCategory(Category category)
        {
            appDbContext?.Categories.Remove(category);
            appDbContext?.SaveChanges();    
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            appDbContext.SaveChanges();
            return appDbContext.Categories;
        }

        public Category GetCategory(int id)
        {
            return appDbContext.Categories.Find(id);
        }

        public Category UpdateCategory(Category category)
        {
            appDbContext.Categories.Update(category);
            appDbContext.SaveChanges();
            return category;
        }
    }
}
