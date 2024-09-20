using MovieReservation.CORE.Entities;

namespace MovieReservation.Business.DTOs.MovieDTOs;
public record MovieGetDto(int Id, string Title, string Description, int Duration, bool IsDeleted, DateTime CreatedDate, 
                         DateTime UpdatedDate, string Genre, DateTime ReleaseDate, ICollection<ShowTime>? ShowTimes);
