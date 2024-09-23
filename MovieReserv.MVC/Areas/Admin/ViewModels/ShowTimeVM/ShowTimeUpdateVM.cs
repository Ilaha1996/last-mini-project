namespace MovieReserv.MVC.Areas.Admin.ViewModels.ShowTimeVM;

public record ShowTimeUpdateVM(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId, bool IsDeleted);

