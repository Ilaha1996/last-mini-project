namespace MovieReservation.Business.DTOs.MovieDTOs;

public record MovieUpdateDto(string Title, string Description, int Duration, bool IsDeleted, string Genre, DateTime ReleaseDate);
