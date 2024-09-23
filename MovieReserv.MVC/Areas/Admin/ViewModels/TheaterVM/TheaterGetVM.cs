using MovieReserv.MVC.Areas.Admin.ViewModels.ShowTimeVM;

namespace MovieReserv.MVC.Areas.Admin.ViewModels.TheaterVM;

public record TheaterGetVM(int Id, string Name, string Location, int TotalSeats, ICollection<ShowTimeGetVM>? ShowTimes,
                        DateTime CreatedDate, DateTime UpdatedDate, bool IsDeleted);

