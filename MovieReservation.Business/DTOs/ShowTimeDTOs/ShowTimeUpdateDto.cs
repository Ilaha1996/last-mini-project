namespace MovieReservation.Business.DTOs.ShowTimeDTOs;
public record ShowTimeUpdateDto(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId, bool IsDeleted);

