using MovieReservation.Business.DTOs.ShowTimeDTOs;
using MovieReservation.CORE.Entities;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Interfaces;
public interface IShowTimeService
{
    Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int? id, ShowTimeUpdateDto dto);
    Task<ShowTimeGetDto> GetByIdAsync(int id);
    Task<ICollection<ShowTimeGetDto>> GetByExpressionAsync(Expression<Func<ShowTime, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
    Task<ShowTimeGetDto> GetSingleByExpressionAsync(Expression<Func<ShowTime, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
}

