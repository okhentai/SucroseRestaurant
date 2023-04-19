using Admin.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models.Foods
{
    public class Food
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert the food name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please insert the food decription")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please insert the food price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Please insert the food category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public int Stock { get; set; }

        public string? PhotoPath { get; set; }

    }
}
