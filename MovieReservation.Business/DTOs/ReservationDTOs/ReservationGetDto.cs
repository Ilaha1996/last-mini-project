using MovieReservation.Business.DTOs.SeatReservationDTOs;

namespace MovieReservation.Business.DTOs.ReservationDTOs;

public record ReservationGetDto(int Id, DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted, DateTime CreatedDate,
                                DateTime UpdatedDate, ICollection<SeatReservationGetDto>? SeatReservations);

