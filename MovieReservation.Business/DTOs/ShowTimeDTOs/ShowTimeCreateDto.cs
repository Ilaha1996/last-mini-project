namespace MovieReservation.Business.DTOs.ShowTimeDTOs;
public record ShowTimeCreateDto(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId);

