using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReservation.CORE.Entities;

namespace MovieReservation.DATA.Configurations
{
    public class SeatReservationConfiguration : IEntityTypeConfiguration<SeatReservation>
    {
        public void Configure(EntityTypeBuilder<SeatReservation> builder)
        {
            builder.Property(x => x.ReservationId)
                .IsRequired();

            builder.Property(x => x.SeatNumber)
                .IsRequired();

            builder.Property(x => x.IsBooked)
                .IsRequired();

            builder.HasOne(x => x.Reservation)
                .WithMany(x => x.SeatReservations) 
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

