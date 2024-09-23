namespace MovieReserv.MVC.Areas.Admin.ViewModels.ReservationVM
{
    public record ReservationCreateVM(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

}
