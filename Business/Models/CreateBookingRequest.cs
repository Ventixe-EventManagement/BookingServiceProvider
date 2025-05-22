namespace Business.Models;

public class CreateBookingRequest
{
    public Guid EventId { get; set; }

    public Guid UserId { get; set; }

    public int TicketQuantity { get; set; } = 1;

    public Guid? PackageId { get; set; }
}
