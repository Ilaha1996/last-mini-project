using MovieReservation.Business.DTOs.ReservationDTOs;

namespace MovieReservation.Business.DTOs.ShowTimeDTOs;
public record ShowTimeGetDto(int Id, DateTime StartTime, DateTime EndTime,bool IsDeleted, int MovieId, int TheaterId, string MovieTitle, 
    string TheaterName, DateTime CreatedDate,DateTime UpdatedDate, ICollection<ReservationGetDto>? Reservations);
