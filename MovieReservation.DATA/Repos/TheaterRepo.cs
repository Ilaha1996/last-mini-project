using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.DAL;

namespace MovieReservation.DATA.Repos;

public class TheaterRepo : GenericRepo<Theater>, ITheaterRepo
{
    public TheaterRepo(AppDbContext context) : base(context) { }

}

