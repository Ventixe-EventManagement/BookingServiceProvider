using Business.Models;

namespace Business.Interfaces;

public interface IBookingService
{
    Task<BookingResult> CreateBooking(CreateBookingRequest request);
    Task<BookingResult> DeleteBookingAsync(Guid id);
    Task<BookingResult> UpdateBookingAsync(Guid id, UpdateBookingRequest request);
}