using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Business.DTOs.MovieDTOs;
using MovieReservation.Business.DTOs.SeatReservationDTOs;
using MovieReservation.Business.Exceptions.CommonExceptions;
using MovieReservation.Business.Services.Interfaces;
using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.Repos;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Implementations;
public class SeatReservationService : ISeatReservationService
{
    private readonly IMapper _mapper;
    private readonly ISeatReservationRepo _seatReservationRepo;

    public SeatReservationService(IMapper mapper, ISeatReservationRepo seatReservationRepo)
    {
        _mapper = mapper;
        _seatReservationRepo = seatReservationRepo;
    }
    public async Task<SeatReservationGetDto> CreateAsync(SeatReservationCreateDto dto)
    {
        SeatReservation seatReservation = _mapper.Map<SeatReservation>(dto);
        seatReservation.CreatedDate = DateTime.Now;
        seatReservation.UpdatedDate = DateTime.Now;
        seatReservation.IsDeleted = false;

        await _seatReservationRepo.CreateAsync(seatReservation);
        await _seatReservationRepo.CommitAsync();

        SeatReservationGetDto getDto = _mapper.Map<SeatReservationGetDto>(seatReservation);

        return getDto;
    }
    public async Task DeleteAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _seatReservationRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        _seatReservationRepo.DeleteAsync(data);
        await _seatReservationRepo.CommitAsync();
    }
    public async Task<ICollection<SeatReservationGetDto>> GetByExpressionAsync(Expression<Func<SeatReservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var datas = await _seatReservationRepo.GetByExpressionAsync(expression, asNoTracking, includes).ToListAsync();  
        if (datas == null) throw new EntityNotFoundException();

        ICollection<SeatReservationGetDto> dtos = _mapper.Map<ICollection<SeatReservationGetDto>>(datas);
        return dtos;
    }
    public async Task<SeatReservationGetDto> GetByIdAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _seatReservationRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        SeatReservationGetDto dto = _mapper.Map<SeatReservationGetDto>(data);

        return dto;
    }
    public async Task<SeatReservationGetDto> GetSingleByExpressionAsync(Expression<Func<SeatReservation, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var data = await _seatReservationRepo.GetByExpressionAsync(expression, asNoTracking, includes).FirstOrDefaultAsync();
        if (data == null) throw new EntityNotFoundException();

        SeatReservationGetDto dto = _mapper.Map<SeatReservationGetDto>(data);

        return dto;
    }
    public async Task UpdateAsync(int? id, SeatReservationUpdateDto dto)
    {
        if (id < 1 || id is null) throw new InvalidIdException();

        var data = await _seatReservationRepo.GetByIdAsync((int)id);
        if (data == null) throw new EntityNotFoundException();

        _mapper.Map(dto, data);

        data.UpdatedDate = DateTime.Now;
        await _seatReservationRepo.CommitAsync();
    }
}
