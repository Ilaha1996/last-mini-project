using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Business.Services.Interfaces;
using MovieReservation.Business.DTOs.MovieDTOs;
using MovieReservation.Business.Exceptions.CommonExceptions;
using MovieReservation.CORE.Entities;
using MovieReservation.CORE.Repos;
using System.Linq.Expressions;

namespace MovieReservation.Business.Services.Implementations;

public class MovieService : IMovieService
{
    private readonly IMovieRepo _movieRepo;
    private readonly IMapper _mapper;

    public MovieService(IMovieRepo movieRepo, IMapper mapper)
    {
        _movieRepo = movieRepo;
        _mapper = mapper;
    }
    public async Task<MovieGetDto> CreateAsync(MovieCreateDto dto)
    {
        Movie movie = _mapper.Map<Movie>(dto);
        movie.CreatedDate = DateTime.Now;
        movie.UpdatedDate = DateTime.Now;
        movie.IsDeleted = false;

        await _movieRepo.CreateAsync(movie);
        await _movieRepo.CommitAsync();

        MovieGetDto getDto = _mapper.Map<MovieGetDto>(movie);

        return getDto;

    }

    public async Task DeleteAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _movieRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();          

        _movieRepo.DeleteAsync(data);
        await _movieRepo.CommitAsync();
    }

    public async Task<ICollection<MovieGetDto>> GetByExpressionAsync(Expression<Func<Movie, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var datas = await _movieRepo.GetByExpressionAsync(expression, asNoTracking, includes).ToListAsync();
        if (datas == null) throw new EntityNotFoundException();

        ICollection<MovieGetDto> dtos = _mapper.Map<ICollection<MovieGetDto>>(datas);
        return dtos;
    }

    public async Task<MovieGetDto> GetByIdAsync(int id)
    {
        if (id < 1) throw new InvalidIdException();
        var data = await _movieRepo.GetByIdAsync(id);
        if (data == null) throw new EntityNotFoundException();

        MovieGetDto dto = _mapper.Map<MovieGetDto>(data);

        return dto;
    }

    public async Task<MovieGetDto> GetSingleByExpressionAsync(Expression<Func<Movie, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
    {
        var data = await _movieRepo.GetByExpressionAsync(expression, asNoTracking, includes).FirstOrDefaultAsync();
        if (data == null) throw new EntityNotFoundException();

        MovieGetDto dto = _mapper.Map<MovieGetDto>(data);

        return dto;
    }

    public async Task UpdateAsync(int? id, MovieUpdateDto dto)
    {
        if (id < 1 || id is null) throw new InvalidIdException();

        var data = await _movieRepo.GetByIdAsync((int)id);
        if (data == null) throw new EntityNotFoundException();       

        _mapper.Map(dto, data);

        data.UpdatedDate = DateTime.Now;
        await _movieRepo.CommitAsync();
    }
}
