using Microsoft.Extensions.DependencyInjection;
using MovieApp.Business.Services.Interfaces;
using MovieReservation.Business.Services.Implementations;
using MovieReservation.Business.Services.Interfaces;

namespace MovieReservation.Business;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {     
        services.AddScoped<ITheaterService, TheaterService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IShowTimeService, ShowTimeService>();
        services.AddScoped<ISeatReservationService, SeatReservationService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
