using MovieReservation.CORE.Entities;

namespace MovieReservation.Business.DTOs.TheaterDTOs;
public record TheaterGetDto(int id, string Name, string Location, int TotalSeats, ICollection<ShowTime>? ShowTimes, DateTime CreatedDate, DateTime UpdatedDate);
