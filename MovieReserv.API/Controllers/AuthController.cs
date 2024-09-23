using Microsoft.AspNetCore.Mvc;
using MovieReserv.API.ApiResponse;
using MovieReservation.Business.DTOs.TokenDTOs;
using MovieReservation.Business.DTOs.UserDTOs;
using MovieReservation.Business.Services.Interfaces;

namespace MovieReserv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            try
            {
                await _authService.Register(dto);
                return Ok(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = null,
                    ErrorMessage = null
                });
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            TokenResponseDto data = null;
            try
            {
                data = await _authService.Login(dto);
                return Ok(new ApiResponse<TokenResponseDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = data,
                    ErrorMessage = null
                });
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new ApiResponse<TokenResponseDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<TokenResponseDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AdminLogin(AdminLoginDto dto)
        {
            TokenResponseDto data = null;
            try
            {
                data = await _authService.AdminLogin(dto);
                return Ok(new ApiResponse<TokenResponseDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = data,
                    ErrorMessage = null
                });
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new ApiResponse<TokenResponseDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<TokenResponseDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
        }
    }
}

//[HttpGet]
//public async Task<IActionResult> CreateRole()
//{
//    IdentityRole role1 = new IdentityRole("SuperAdmin");
//    IdentityRole role2 = new IdentityRole("Admin");
//    IdentityRole role3 = new IdentityRole("Member");
//    IdentityRole role4 = new IdentityRole("Editor");

//    await _roleManager.CreateAsync(role1);
//    await _roleManager.CreateAsync(role4);
//    await _roleManager.CreateAsync(role2);
//    await _roleManager.CreateAsync(role3);

//    return Ok();
//}

//[HttpGet]
//public async Task<IActionResult> CreateAdmin()
//{
//    AppUser appUser = new AppUser()
//    {
//        UserName = "Ilaha",
//        Email = "ilahahasanova@yahoo.com",
//        Fullname = "Ilaha Hasanova"
//    };

//    await _userManager.CreateAsync(appUser, "Salam123!");
//    return Ok();

//}

//[HttpGet]
//public async Task<IActionResult> AddRole()
//{
//    AppUser appUser = await _userManager.FindByNameAsync("Ilaha");

//    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");
//    return Ok();

//}