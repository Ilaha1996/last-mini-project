using MovieReservation.Business.DTOs.TokenDTOs;
using MovieReservation.Business.DTOs.UserDTOs;

namespace MovieReservation.Business.Services.Interfaces;

public interface IAuthService
{
    Task Register(UserRegisterDto dto);
    Task<TokenResponseDto> Login(UserLoginDto dto);
    Task<TokenResponseDto> AdminLogin(AdminLoginDto dto);
}
