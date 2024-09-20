using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.DAL;

namespace MovieReservation.DATA.Repos;

public class ReservationRepo : GenericRepo<Reservation>, IReservationRepo
{
    public ReservationRepo(AppDbContext context) : base(context) { }

}
