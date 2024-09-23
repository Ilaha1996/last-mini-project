namespace MovieReserv.MVC.Areas.Admin.ViewModels.MovieVM;

public record MovieUpdateVM(string Title, string Description, int Duration, bool IsDeleted, string Genre, DateTime ReleaseDate);

