namespace MovieReservation.CORE.Entities;

public class Reservation:BaseEntity
{
    public string AppUserId { get; set; }
    public int ShowTimeId { get; set; }
    public DateTime ReservationDate { get; set; }
    public AppUser AppUser { get; set; }
    public ShowTime ShowTime { get; set; }
    public ICollection<SeatReservation>? SeatReservations { get; set; } 
}
