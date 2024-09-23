using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReservation.CORE.Entities;

namespace MovieReservation.DATA.Configurations
{
    public class ShowTimeConfiguration : IEntityTypeConfiguration<ShowTime>
    {
        public void Configure(EntityTypeBuilder<ShowTime> builder)
        {
            builder.Property(x => x.MovieId)
                .IsRequired();

            builder.Property(x => x.TheaterId)
                .IsRequired();

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.ShowTimes)
                .HasForeignKey(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(x => x.Theater)
                .WithMany(x=>x.ShowTimes) 
                .HasForeignKey(x => x.TheaterId)
                .OnDelete(DeleteBehavior.Cascade);                      
        }
    }
}

