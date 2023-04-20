using Admin.Models.Bookings;
using Admin.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class BookingController : Controller
    {   
        private readonly IBookingRep bookingRep;
        private readonly UserManager<User> _userManager;


        public BookingController(IBookingRep bookingRep, UserManager<User> userManager)
        {
            this.bookingRep = bookingRep;
            _userManager = userManager;
        }

        public async Task<IActionResult> List()
        {
            var booking = await bookingRep.GetAllAsync();
            return View(booking);
        }

        public async Task<IActionResult> Accept(int id)
        {
            var booking = await bookingRep.GetByIdAsync(id);
            if (booking != null)
            {
                booking.DaXacNhan = true;
                await bookingRep.UpdateAsync(booking);
                return RedirectToAction("List");
            }
            return NotFound();

        }
        public async Task<IActionResult> Denied(int id)
        {
            var booking = await bookingRep.GetByIdAsync(id);
            if (booking != null)
            {
                booking.DaTuChoi = true;
                await bookingRep.UpdateAsync(booking);
                return RedirectToAction("List");
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var booking = new Booking
                {
                    Name = user.FullName,
                    Phone = user.PhoneNumber,
                    
                };
                return View(booking);
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(Booking model)
        {
            if (ModelState.IsValid)
            {
                var booking = new Booking
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    People = model.People,
                    Date = model.Date,
                    Message = model.Message
                    
                };

                await bookingRep.AddAsync(booking);
                return RedirectToAction("Thanks");
            }

            return View(model);
        }

        public IActionResult Thanks()
        {
            return View();
        }
        
    }
}
