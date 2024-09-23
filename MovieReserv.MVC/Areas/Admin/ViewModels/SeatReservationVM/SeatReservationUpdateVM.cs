namespace MovieReserv.MVC.Areas.Admin.ViewModels.SeatReservationVM;

public record SeatReservationUpdateVM(int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);

