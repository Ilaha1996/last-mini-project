namespace MovieReservation.Business.DTOs.TheaterDTOs;
public record TheaterUpdateDto(string Name, string Location, int TotalSeats, bool IsDeleted);
