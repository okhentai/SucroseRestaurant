using Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace Admin.Models.Bookings
{
    public class BookingRep : IBookingRep
    {
        private readonly AppDbContext _appDbContext;
        public BookingRep(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Booking booking)
        {
            await _appDbContext.Set<Booking>().AddAsync(booking);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await GetByIdAsync(id);
            if (booking != null)
            {
                _appDbContext.Set<Booking>().Remove(booking);
                await _appDbContext.SaveChangesAsync();

            }
        }
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _appDbContext.Set<Booking>()
                        .ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<Booking>()
            .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _appDbContext.Set<Booking>().Update(booking);
            await _appDbContext.SaveChangesAsync();
        }
    }
}

