using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.DAL;

namespace MovieReservation.DATA.Repos;

public class MovieRepo : GenericRepo<Movie>, IMovieRepo
{
    public MovieRepo(AppDbContext context) : base(context) { }

}
