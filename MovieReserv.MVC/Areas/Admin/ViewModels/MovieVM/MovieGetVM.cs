using MovieReserv.MVC.Areas.Admin.ViewModels.ShowTimeVM;

namespace MovieReserv.MVC.Areas.Admin.ViewModels.MovieVM;
public record MovieGetVM(int Id, string Title, string Description, int Duration, bool IsDeleted, DateTime CreatedDate,
                     DateTime UpdatedDate, string Genre, DateTime ReleaseDate, ICollection<ShowTimeGetVM>? ShowTimes);
