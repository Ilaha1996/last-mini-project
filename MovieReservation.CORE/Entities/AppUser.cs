using Microsoft.AspNetCore.Identity;

namespace MovieReservation.CORE.Entities;

public class AppUser : IdentityUser
{   
    public ICollection<Reservation> Reservations { get; set; }
}
