using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.DAL;
using MovieReservation.DATA.Repos;

namespace MovieReservation.DATA;

public static class ServiceRegistration
{

    public static void AddRepos(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IMovieRepo, MovieRepo>();
        services.AddScoped<IReservationRepo, ReservationRepo>();
        services.AddScoped<ITheaterRepo, TheaterRepo>();
        services.AddScoped<ISeatReservationRepo, SeatReservationRepo>();
        services.AddScoped<IShowTimeRepo, ShowTimeRepo>();


        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
    }
}