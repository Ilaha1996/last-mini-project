using FluentValidation;

namespace MovieReservation.Business.DTOs.ReservationDTOs;
public record ReservationCreateDto(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
{
    public ReservationCreateDtoValidator()
    {   
        RuleFor(x => x.IsDeleted).NotNull();
        RuleFor(x => x.AppUserId).NotNull().NotEmpty();
        RuleFor(x=> x.ShowTimeId).NotNull().NotEmpty();    
    }
}

