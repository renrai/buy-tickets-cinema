using AutoMapper;
using DataApplication.Database.Entities;
using DataRestApplication.DTO;
using DomainApplication.Models;
using System;

namespace DataApplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AuditoriumEntity, Auditorium>()
            .ReverseMap();
            CreateMap<ShowtimeEntity, Showtime>()
                        .ReverseMap();
            CreateMap<MovieEntity, Movie>()
            .ReverseMap();
            CreateMap<TicketEntity, Ticket>()
            .ReverseMap();
            CreateMap<SeatEntity, Seat>()
            .ReverseMap();
            CreateMap<ReservationSeatsEntity, ReservationSeats>()
                .ReverseMap();
            CreateMap<IMDBMovieDTO, Movie>()
            .ReverseMap();
            CreateMap<ReservationEntity, Reservation>()
                .ReverseMap();
        }
    }
}
