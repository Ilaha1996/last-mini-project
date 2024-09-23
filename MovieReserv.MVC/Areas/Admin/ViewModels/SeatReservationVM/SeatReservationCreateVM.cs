namespace MovieReserv.MVC.Areas.Admin.ViewModels.SeatReservationVM;

public record SeatReservationCreateVM(int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);

