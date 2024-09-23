using FluentValidation;

namespace MovieReservation.Business.DTOs.SeatReservationDTOs;
public record SeatReservationCreateDto(int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);

public class SeatReservationCreateDtoValidator : AbstractValidator<SeatReservationCreateDto>
{
    public SeatReservationCreateDtoValidator()
    {
        RuleFor(x => x.SeatNumber)
            .GreaterThan(0)
            .WithMessage("Seat number must be greater than 0.");

        RuleFor(x => x.IsBooked)
            .NotNull()
            .WithMessage("IsBooked field is required.");

        RuleFor(x => x.ReservationId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.IsDeleted)
            .NotNull()
            .WithMessage("IsDeleted field is required.");
    }
}