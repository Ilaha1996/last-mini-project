using MovieReservation.Business.DTOs.TheaterDTOs;
using MovieReservation.CORE.Entities;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Interfaces;
public interface ITheaterService
{
    Task<TheaterGetDto> CreateAsync(TheaterCreateDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int? id, TheaterUpdateDto dto);
    Task<TheaterGetDto> GetByIdAsync(int id);
    Task<ICollection<TheaterGetDto>> GetByExpressionAsync(Expression<Func<Theater, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
    Task<TheaterGetDto> GetSingleByExpressionAsync(Expression<Func<Theater, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
}
