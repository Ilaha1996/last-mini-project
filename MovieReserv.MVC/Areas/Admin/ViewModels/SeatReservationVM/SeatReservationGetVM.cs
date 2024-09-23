namespace MovieReserv.MVC.Areas.Admin.ViewModels.SeatReservationVM;

public record SeatReservationGetVM(int Id, int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted,
                                    DateTime CreatedDate, DateTime UpdatedDate);

