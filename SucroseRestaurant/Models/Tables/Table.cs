using System.ComponentModel.DataAnnotations;

namespace SucroseRestaurant.Models.Tables
{
    public class Table
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
