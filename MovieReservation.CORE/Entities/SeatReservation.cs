namespace MovieReservation.CORE.Entities;

public class SeatReservation:BaseEntity
{ 
    public int ReservationId { get; set; }
    public int SeatNumber{ get; set; }
    public bool IsBooked { get; set; }
    public Reservation Reservation { get; set; }
    
}
