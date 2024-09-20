using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Business.DTOs.ShowTimeDTOs;
using MovieReservation.Business.Exceptions.CommonExceptions;
using MovieReservation.Business.Services.Interfaces;
using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Implementations;
public class ShowTimeService : IShowTimeService
{
    private readonly IMapper _mapper;
    private readonly IShowTimeRepo _showTimeRepo;

    public ShowTimeService(IMapper mapper, IShowTimeRepo showTimeRepo)
    {
        _mapper = mapper;
        _showTimeRepo = showTimeRepo;
    }
    public async Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto)
    {
        ShowTime showTime = _mapper.Map<ShowTime>(dto);
        showTime.CreatedDate = DateTime.Now;
        showTime.UpdatedDate = DateTime.Now;
        showTime.IsDeleted = false;

        await _showTimeRepo.CreateAsync(showTime);
        await _showTimeRepo.CommitAsync();

        ShowTimeGetDto getDto = _mapper.Map<ShowTimeGetDto>(showTime);

        return getDto;
    }

    public async Task DeleteAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _showTimeRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        _showTimeRepo.DeleteAsync(data);
        await _showTimeRepo.CommitAsync();
    }

    public async Task<ICollection<ShowTimeGetDto>> GetByExpressionAsync(Expression<Func<ShowTime, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var datas = await _showTimeRepo.GetByExpressionAsync(expression, asNoTracking, includes).ToListAsync();
        if (datas == null) throw new EntityNotFoundException();

        ICollection<ShowTimeGetDto> dtos = _mapper.Map<ICollection<ShowTimeGetDto>>(datas);
        return dtos;
    }

    public async Task<ShowTimeGetDto> GetByIdAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _showTimeRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        ShowTimeGetDto dto = _mapper.Map<ShowTimeGetDto>(data);

        return dto;
    }

    public async Task<ShowTimeGetDto> GetSingleByExpressionAsync(Expression<Func<ShowTime, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var data = await _showTimeRepo.GetByExpressionAsync(expression, asNoTracking, includes).FirstOrDefaultAsync();
        if (data == null) throw new EntityNotFoundException();

        ShowTimeGetDto dto = _mapper.Map<ShowTimeGetDto>(data);

        return dto;
    }

    public async Task UpdateAsync(int? id, ShowTimeUpdateDto dto)
    {
        if (id < 1 || id is null) throw new InvalidIdException();

        var data = await _showTimeRepo.GetByIdAsync((int)id);
        if (data == null) throw new EntityNotFoundException();

        _mapper.Map(dto, data);

        data.UpdatedDate = DateTime.Now;
        await _showTimeRepo.CommitAsync();
    }
}
