using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class BookingFactory
{
    public static BookingEntity FromRequest(CreateBookingRequest request)
    {
        return new BookingEntity
        {
            Id = Guid.NewGuid(),
            EventId = request.EventId,
            PackageId = request.PackageId,
            UserId = request.UserId,
            TicketQuantity = request.TicketQuantity,
            BookingDate = DateTime.UtcNow
        };
    }
}