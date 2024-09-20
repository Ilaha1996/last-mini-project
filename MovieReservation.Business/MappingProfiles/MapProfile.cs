using AutoMapper;
using MovieReservation.Business.DTOs.MovieDTOs;
using MovieReservation.Business.DTOs.ReservationDTOs;
using MovieReservation.Business.DTOs.SeatReservationDTOs;
using MovieReservation.Business.DTOs.ShowTimeDTOs;
using MovieReservation.Business.DTOs.TheaterDTOs;
using MovieReservation.CORE.Entities;

namespace MovieReservation.Business.MappingProfiles;

public class MapProfile: Profile
{
    public MapProfile()
    {
        CreateMap<Movie, MovieGetDto>().ReverseMap();
        CreateMap<MovieCreateDto, Movie>().ReverseMap();
        CreateMap<MovieUpdateDto, Movie>().ReverseMap();

        CreateMap<Reservation, ReservationGetDto>().ReverseMap();
        CreateMap<ReservationCreateDto, Reservation>().ReverseMap();
        CreateMap<ReservationUpdateDto, Reservation>().ReverseMap();

        CreateMap<SeatReservation, SeatReservationGetDto>().ReverseMap();
        CreateMap<SeatReservationCreateDto, SeatReservation>().ReverseMap();
        CreateMap<SeatReservationUpdateDto, SeatReservation>().ReverseMap();

        CreateMap<ShowTime, ShowTimeGetDto>().ReverseMap();
        CreateMap<ShowTimeCreateDto, ShowTime>().ReverseMap();
        CreateMap<ShowTimeUpdateDto, ShowTime>().ReverseMap();

        CreateMap<Theater, TheaterGetDto>().ReverseMap();
        CreateMap<TheaterCreateDto, Theater>().ReverseMap();
        CreateMap<TheaterUpdateDto, Theater>().ReverseMap();

    }
}
