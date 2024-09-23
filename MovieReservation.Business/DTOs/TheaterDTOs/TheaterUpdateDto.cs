using FluentValidation;

namespace MovieReservation.Business.DTOs.TheaterDTOs;
public record TheaterUpdateDto(string Name, string Location, int TotalSeats, bool IsDeleted);

public class TheaterUpdateDtoValidator : AbstractValidator<TheaterUpdateDto>
{
    public TheaterUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(150).WithMessage("Location cannot exceed 150 characters.");

        RuleFor(x => x.TotalSeats)
            .GreaterThan(0).WithMessage("TotalSeats must be a positive integer.");

        RuleFor(x => x.IsDeleted).NotNull();
    }
}