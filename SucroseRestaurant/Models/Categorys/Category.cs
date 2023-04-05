using System.ComponentModel.DataAnnotations;
using SucroseRestaurant.Models.Foods;

namespace Admin.Models.Categorys
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert category name")]
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        //RelationShip to Food 
        public List<Food> Foods { get; set; }
    }
}
