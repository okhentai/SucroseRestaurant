using System.ComponentModel.DataAnnotations;
using Admin.Models.Foods;

namespace Admin.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert category name")]
        public string Name { get; set; }

        //RelationShip to Food 
        public List<Food>? Foods { get; set; }
    }
}
    