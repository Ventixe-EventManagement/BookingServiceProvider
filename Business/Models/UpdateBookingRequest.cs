namespace Business.Models;

public class UpdateBookingRequest
{
    public int TicketQuantity { get; set; }
    public Guid? PackageId { get; set; }
}