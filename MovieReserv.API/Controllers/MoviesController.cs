using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services.Interfaces;
using MovieReserv.API.ApiResponse;
using MovieReservation.Business.DTOs.MovieDTOs;

namespace MovieReserv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<MovieGetDto>>
            {
                Data = await _movieService.GetByExpressionAsync(null, true, null),
                ErrorMessage = null,
                PropertyName = null,
                StatusCode = StatusCodes.Status200OK

            });
        }
    }
}
