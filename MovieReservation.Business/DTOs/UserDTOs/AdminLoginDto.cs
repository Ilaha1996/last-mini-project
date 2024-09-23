using FluentValidation;

namespace MovieReservation.Business.DTOs.UserDTOs;

public record AdminLoginDto(string Username, string Password, bool RememberMe);

public class AdminLoginDtoValidator : AbstractValidator<AdminLoginDto>
{
    public AdminLoginDtoValidator()
    {
        RuleFor(x => x.Username).NotEmpty().MaximumLength(50).MinimumLength(2);
        RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
    }
}

