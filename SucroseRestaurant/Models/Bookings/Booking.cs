using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Bookings
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int People { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Message { get; set; }
        public bool DaXacNhan { get; set; }
        public bool DaTuChoi { get; set; }
    }
}
