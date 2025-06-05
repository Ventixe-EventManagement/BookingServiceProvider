using Data.Entities;

namespace Data.Interfaces;

public interface IBookingRepository : IBaseRepository<BookingEntity>
{
    Task<IEnumerable<BookingEntity>> GetBookingsByUserIdAsync(Guid userId);
}