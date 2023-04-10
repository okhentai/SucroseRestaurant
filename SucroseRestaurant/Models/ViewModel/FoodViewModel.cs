using Admin.Models.Categories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Models.ViewModel
{
    public class FoodViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert the food name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please insert the food decription")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please insert the food price")]
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }

        public int Stock { get; set; }

        public IFormFile PhotoPath { get; set; }
    }
}
