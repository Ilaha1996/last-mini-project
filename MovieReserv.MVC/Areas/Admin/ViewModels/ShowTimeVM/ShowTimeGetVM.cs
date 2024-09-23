using MovieReserv.MVC.Areas.Admin.ViewModels.ReservationVM;

namespace MovieReserv.MVC.Areas.Admin.ViewModels.ShowTimeVM;

public record ShowTimeGetVM(int Id, DateTime StartTime, DateTime EndTime, bool IsDeleted, int MovieId, int TheaterId, string MovieTitle,
    string TheaterName, DateTime CreatedDate, DateTime UpdatedDate, ICollection<ReservationGetVM>? Reservations);

