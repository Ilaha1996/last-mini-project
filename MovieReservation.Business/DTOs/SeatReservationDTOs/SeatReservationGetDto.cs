namespace MovieReservation.Business.DTOs.SeatReservationDTOs;
public record SeatReservationGetDto(int Id,int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted, 
                                    DateTime CreatedDate, DateTime UpdatedDate);

