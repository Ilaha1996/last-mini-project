using MovieReservation.Business.DTOs.ReservationDTOs;
using MovieReservation.CORE.Entities;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Interfaces;
public interface IReservationService
{
    Task<ReservationGetDto> CreateAsync(ReservationCreateDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int? id, ReservationUpdateDto dto);
    Task<ReservationGetDto> GetByIdAsync(int id);
    Task<bool> IsExistAsync(Expression<Func<Reservation, bool>> predicate);
    Task<ICollection<ReservationGetDto>> GetByExpressionAsync(Expression<Func<Reservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
    Task<ReservationGetDto> GetSingleByExpressionAsync(Expression<Func<Reservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
}


