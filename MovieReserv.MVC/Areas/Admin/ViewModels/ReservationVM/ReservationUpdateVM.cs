namespace MovieReserv.MVC.Areas.Admin.ViewModels.ReservationVM;

public record ReservationUpdateVM(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

