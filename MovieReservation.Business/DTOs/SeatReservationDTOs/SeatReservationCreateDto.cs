namespace MovieReservation.Business.DTOs.SeatReservationDTOs;
public record SeatReservationCreateDto(int SeatNumber, bool IsBooked, int ReservationId);
