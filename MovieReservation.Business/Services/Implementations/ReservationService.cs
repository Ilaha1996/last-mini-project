using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Business.DTOs.MovieDTOs;
using MovieReservation.Business.DTOs.ReservationDTOs;
using MovieReservation.Business.Exceptions.CommonExceptions;
using MovieReservation.Business.Services.Interfaces;
using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.Repos;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Implementations;
public class ReservationService : IReservationService
{
    private readonly IReservationRepo _reservationRepo;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepo reservationRepo, IMapper mapper)
    {
        _reservationRepo = reservationRepo;
        _mapper = mapper;
    }
    public async Task<ReservationGetDto> CreateAsync(ReservationCreateDto dto)
    {
        Reservation reservation = _mapper.Map<Reservation>(dto);
        reservation.CreatedDate = DateTime.Now;
        reservation.UpdatedDate = DateTime.Now;
        reservation.IsDeleted = false;

        await _reservationRepo.CreateAsync(reservation);
        await _reservationRepo.CommitAsync();

        ReservationGetDto getDto = _mapper.Map<ReservationGetDto>(reservation);

        return getDto;
    }

    public async Task DeleteAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _reservationRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        _reservationRepo.DeleteAsync(data);
        await _reservationRepo.CommitAsync();
    }

    public async Task<ICollection<ReservationGetDto>> GetByExpressionAsync(Expression<Func<Reservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var datas = await _reservationRepo.GetByExpressionAsync(expression, asNoTracking, includes).ToListAsync();
        if (datas == null) throw new EntityNotFoundException();

        ICollection<ReservationGetDto> dtos = _mapper.Map<ICollection<ReservationGetDto>>(datas);
        return dtos;
    }

    public async Task<ReservationGetDto> GetByIdAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _reservationRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        ReservationGetDto dto = _mapper.Map<ReservationGetDto>(data);

        return dto;
    }

    public async Task<ReservationGetDto> GetSingleByExpressionAsync(Expression<Func<Reservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var data = await _reservationRepo.GetByExpressionAsync(expression, asNoTracking, includes).FirstOrDefaultAsync();
        if (data == null) throw new EntityNotFoundException();

        ReservationGetDto dto = _mapper.Map<ReservationGetDto>(data);

        return dto;
    }

    public async Task UpdateAsync(int? id, ReservationUpdateDto dto)
    {
        if (id < 1 || id is null) throw new InvalidIdException();

        var data = await _reservationRepo.GetByIdAsync((int)id);
        if (data == null) throw new EntityNotFoundException();

        _mapper.Map(dto, data);

        data.UpdatedDate = DateTime.Now;
        await _reservationRepo.CommitAsync();
    }

    public async Task<bool> IsExistAsync(Expression<Func<Reservation, bool>>? expression = null)
    {
        if (expression == null)
        {
            return false;
        }

        var exists = await _reservationRepo.GetByExpressionAsync(expression).AnyAsync();
        return exists;
    }
}
