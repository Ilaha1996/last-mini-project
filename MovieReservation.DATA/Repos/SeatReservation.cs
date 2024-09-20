using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.DAL;

namespace MovieReservation.DATA.Repos;

public class SeatReservationRepo : GenericRepo<SeatReservation>, ISeatReservationRepo
{
    public SeatReservationRepo(AppDbContext context) : base(context) { }

}
