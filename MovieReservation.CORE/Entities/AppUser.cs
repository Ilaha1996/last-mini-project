using Microsoft.AspNetCore.Identity;

namespace MovieReservation.CORE.Entities;

public class AppUser : IdentityUser
{   
    public string Fulname { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
