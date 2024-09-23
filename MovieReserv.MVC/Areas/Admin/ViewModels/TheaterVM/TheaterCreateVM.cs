namespace MovieReserv.MVC.Areas.Admin.ViewModels.TheaterVM;

public record TheaterCreateVM(string Name, string Location, int TotalSeats, bool IsDeleted);
