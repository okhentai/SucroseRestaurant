using System.ComponentModel.DataAnnotations;

namespace SucroseRestaurant.Models.Foods
{
    public class Food
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert the food name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please insert the food decription")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please insert the food price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Please insert the food Category")]
        public int Category { get; set; }

        public int Stock { get; set; }

        public string PhotoPath { get; set; }
        public int PhotoLink { get; set;}

    }
}
