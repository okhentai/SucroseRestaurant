namespace Admin.Models.Bookings
{
    public interface IBookingRep
    {
        Task<Booking> GetByIdAsync(int id);
        Task<List<Booking>> GetAllAsync();
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int id);
    }
}
