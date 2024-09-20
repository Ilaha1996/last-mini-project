namespace MovieReservation.Business.DTOs.SeatReservationDTOs;
public record SeatReservationUpdateDto(int SeatNumber, bool IsBooked, int ReservationId,bool IsDeleted);

