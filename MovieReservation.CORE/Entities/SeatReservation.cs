namespace MovieReservation.CORE.Entities;

public class SeatReservation:BaseEntity
{
    public string AppUserId { get; set; }
    public int ShowTimeId { get; set; }
    public int SeatNumber{ get; set; }
    public bool IsBooked { get; set; }
    public ShowTime ShowTime { get; set; }
    public AppUser AppUser { get; set; }
    
}
