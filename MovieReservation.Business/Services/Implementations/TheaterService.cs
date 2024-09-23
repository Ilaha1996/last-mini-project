using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Business.DTOs.MovieDTOs;
using MovieReservation.Business.DTOs.TheaterDTOs;
using MovieReservation.Business.Exceptions.CommonExceptions;
using MovieReservation.Business.Services.Interfaces;
using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using MovieReservation.DATA.Repos;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Implementations;

public class TheaterService : ITheaterService
{
    private readonly IMapper _mapper;
    private readonly ITheaterRepo _theaterRepo;
    public TheaterService(IMapper mapper, ITheaterRepo theaterRepo )
    {
        _mapper = mapper;
        _theaterRepo = theaterRepo;
    }
    public async Task<TheaterGetDto> CreateAsync(TheaterCreateDto dto)
    {
        Theater theater = _mapper.Map<Theater>(dto);
        theater.CreatedDate = DateTime.Now;
        theater.UpdatedDate = DateTime.Now;
        theater.IsDeleted = false;

        await _theaterRepo.CreateAsync(theater);
        await _theaterRepo.CommitAsync();

        TheaterGetDto getDto = _mapper.Map<TheaterGetDto>(theater);

        return getDto;
    }
    public async Task DeleteAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _theaterRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        _theaterRepo.DeleteAsync(data);
        await _theaterRepo.CommitAsync();
    }  

    public async Task<ICollection<TheaterGetDto>> GetByExpressionAsync(Expression<Func<Theater, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var datas = await _theaterRepo.GetByExpressionAsync(expression, asNoTracking, includes).ToListAsync();
        if (datas == null) throw new EntityNotFoundException();

        ICollection<TheaterGetDto> dtos = _mapper.Map<ICollection<TheaterGetDto>>(datas);
        return dtos;
    }

    public async Task<TheaterGetDto> GetByIdAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _theaterRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        TheaterGetDto dto = _mapper.Map<TheaterGetDto>(data);
        
        return dto;
    }

    public async Task<TheaterGetDto> GetSingleByExpressionAsync(Expression<Func<Theater, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var data = await _theaterRepo.GetByExpressionAsync(expression, asNoTracking, includes).FirstOrDefaultAsync();
        if (data == null) throw new EntityNotFoundException();

        TheaterGetDto dto = _mapper.Map<TheaterGetDto>(data);

        return dto;
    }

    public async Task<bool> IsExistAsync(Expression<Func<Theater, bool>>? expression = null)
    {
        if (expression == null)
        {
            return false; 
        }

        var exists = await _theaterRepo.GetByExpressionAsync(expression).AnyAsync();
        return exists;
    }


    public async Task UpdateAsync(int? id, TheaterUpdateDto dto)
    {
        if (id < 1 || id is null) throw new InvalidIdException();

        var data = await _theaterRepo.GetByIdAsync((int)id);
        if (data == null) throw new EntityNotFoundException();

        _mapper.Map(dto, data);

        data.UpdatedDate = DateTime.Now;
        await _theaterRepo.CommitAsync();
    }
}
