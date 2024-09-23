namespace MovieReserv.MVC.Areas.Admin.ViewModels.MovieVM;
public record MovieCreateVM(string Title, string Description, int Duration, DateTime ReleaseDate, string Genre, bool IsDeleted);

