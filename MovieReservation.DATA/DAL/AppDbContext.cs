using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieReservation.CORE.Entities;

namespace MovieReservation.DATA.DAL;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Reservation> Reservations  { get; set; }
    public DbSet<SeatReservation> SeatReservations  { get; set; }
    public DbSet<ShowTime> ShowTimes { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<AppUser> Users { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);
    //    base.OnModelCreating(modelBuilder);
    //}

}
