using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.DAL;

namespace MovieReservation.DATA.Repos;

public class ShowTimeRepo: GenericRepo<ShowTime>, IShowTimeRepo
{
    public ShowTimeRepo(AppDbContext context) : base(context) { }

}

