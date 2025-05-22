using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class BookingEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EventId { get; set; }

    public int TicketQuantity { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    [Required]
    public Guid UserId { get; set; } // TO DO koppla via Auth senare ANNARS måste jag lägga till bookingowner osv om jag inte hinner fixa inlogg

    public Guid? PackageId { get; set; }
}
