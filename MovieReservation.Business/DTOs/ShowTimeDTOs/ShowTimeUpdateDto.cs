using FluentValidation;

namespace MovieReservation.Business.DTOs.ShowTimeDTOs;
public record ShowTimeUpdateDto(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId, bool IsDeleted);

public class ShowTimeUpdateDtoValidator : AbstractValidator<ShowTimeUpdateDto>
{
    public ShowTimeUpdateDtoValidator()
    {

        RuleFor(x => x.IsDeleted).NotNull();
        RuleFor(x => x.MovieId).NotNull().NotEmpty();
        RuleFor(x => x.TheaterId).NotNull().NotEmpty();
        RuleFor(x => x.StartTime)
               .NotEmpty().WithMessage("StartTime is required.")
               .GreaterThan(DateTime.Now).WithMessage("StartTime must be in the future.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("EndTime is required.")
            .GreaterThan(x => x.StartTime).WithMessage("EndTime must be after StartTime.");
    }
}