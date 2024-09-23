using MovieReservation.Business.DTOs.ShowTimeDTOs;

namespace MovieReservation.Business.DTOs.TheaterDTOs;
public record TheaterGetDto(int id, string Name, string Location, int TotalSeats, ICollection<ShowTimeGetDto>? ShowTimes, 
                            DateTime CreatedDate, DateTime UpdatedDate);
