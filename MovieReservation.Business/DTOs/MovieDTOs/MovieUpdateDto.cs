namespace MovieReservation.Business.DTOs.MovieDTOs;

public record MovieUpdateDto(string Title, string Description, int Duration, bool IsDeleted, DateTime UpdatedDate, string Genre, DateTime ReleaseDate);
