using FluentValidation;

namespace MovieReservation.Business.DTOs.ReservationDTOs;
public record ReservationUpdateDto(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

public class ReservationUpdateDtoValidator : AbstractValidator<ReservationUpdateDto>
{
    public ReservationUpdateDtoValidator()
    {
        RuleFor(x => x.IsDeleted).NotNull();
        RuleFor(x => x.AppUserId).NotNull().NotEmpty();
        RuleFor(x => x.ShowTimeId).NotNull().NotEmpty();
    }
}