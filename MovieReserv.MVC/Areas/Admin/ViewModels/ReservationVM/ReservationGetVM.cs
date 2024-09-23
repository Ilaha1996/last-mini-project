using MovieReserv.MVC.Areas.Admin.ViewModels.SeatReservationVM;

namespace MovieReserv.MVC.Areas.Admin.ViewModels.ReservationVM;

public record ReservationGetVM (int Id, DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted, DateTime CreatedDate,
                            DateTime UpdatedDate, ICollection<SeatReservationGetVM>? SeatReservations);
