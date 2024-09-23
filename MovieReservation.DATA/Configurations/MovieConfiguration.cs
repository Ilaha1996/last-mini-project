using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieReservation.CORE.Entities;

namespace MovieReservation.DATA.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(800);

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.Rating)
                       .IsRequired(false) 
                       .HasPrecision(3, 2) 
                       .HasDefaultValue(null); 

            builder.Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ReleaseDate)
                .IsRequired();
        
        }
    }
}
