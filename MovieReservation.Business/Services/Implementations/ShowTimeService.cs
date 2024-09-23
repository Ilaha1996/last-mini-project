using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Business.Services.Interfaces;
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
    private readonly ITheaterService _theaterService;
    private readonly IMovieService _movieService;

    public ShowTimeService(IMapper mapper, IShowTimeRepo showTimeRepo, ITheaterService theaterService, IMovieService movieService)
    {
        _mapper = mapper;
        _showTimeRepo = showTimeRepo;
        _theaterService = theaterService;
        _movieService = movieService;
    }
    public async Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto)
    {
        if (!await _movieService.IsExistAsync(x => x.Id == dto.MovieId && x.IsDeleted == false)) throw new EntityNotFoundException();
        if (!await _theaterService.IsExistAsync(x => x.Id == dto.TheaterId && x.IsDeleted == false)) throw new EntityNotFoundException();
        
        ShowTime showTime = _mapper.Map<ShowTime>(dto);
        showTime.CreatedDate = DateTime.Now;
        showTime.UpdatedDate = DateTime.Now;
     
        await _showTimeRepo.CreateAsync(showTime);
        await _showTimeRepo.CommitAsync();

        ShowTimeGetDto getDto = _mapper.Map<ShowTimeGetDto>(showTime);

        return getDto;
    }

    public async Task DeleteAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _showTimeRepo.GetByExpressionAsync(x => x.Id == id, false, "Theater", "Movie").FirstOrDefaultAsync();
        if (data == null) throw new EntityNotFoundException();

        _showTimeRepo.DeleteAsync(data);
        await _showTimeRepo.CommitAsync();
    }

    public async Task<ICollection<ShowTimeGetDto>> GetByExpressionAsync(Expression<Func<ShowTime, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        IQueryable<ShowTime> query = _showTimeRepo.GetByExpressionAsync(expression, asNoTracking);
        
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var datas = await query.ToListAsync();
        if (datas == null || !datas.Any()) throw new EntityNotFoundException();

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

        if (!await _movieService.IsExistAsync(x => x.Id == dto.MovieId && x.IsDeleted == false)) throw new EntityNotFoundException();
        if (!await _theaterService.IsExistAsync(x => x.Id == dto.TheaterId && x.IsDeleted == false)) throw new EntityNotFoundException();
        if (id < 1 || id is null) throw new InvalidIdException();

        var data = await _showTimeRepo.GetByIdAsync((int)id);
        if (data == null) throw new EntityNotFoundException();

        _mapper.Map(dto, data);

        data.UpdatedDate = DateTime.Now;
        await _showTimeRepo.CommitAsync();
    }

}
