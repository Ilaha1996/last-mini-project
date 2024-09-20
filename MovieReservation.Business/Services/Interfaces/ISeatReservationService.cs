using MovieReservation.Business.DTOs.SeatReservationDTOs;
using MovieReservation.CORE.Entities;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Interfaces;
public interface ISeatReservationService
{
    Task<SeatReservationGetDto> CreateAsync(SeatReservationCreateDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int? id, SeatReservationUpdateDto dto);
    Task<SeatReservationGetDto> GetByIdAsync(int id);
    Task<ICollection<SeatReservationGetDto>> GetByExpressionAsync(Expression<Func<SeatReservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
    Task<SeatReservationGetDto> GetSingleByExpressionAsync(Expression<Func<SeatReservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
}

