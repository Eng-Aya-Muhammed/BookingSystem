using AutoMapper;
using BookingSystem.Core.Features.Reservations.Commands;
using BookingSystem.Core.Models;
using BookingSystem.Core.DTOs.Reservation;
using BookingSystem.Core.Features.Auth.Commands;
using BookingSystem.Core.DTOs.Auth;

namespace BookingSystem.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDto>()
             .ForMember(dest => dest.TripName, opt => opt.MapFrom(src => src.Trip.Name));
            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationCommand, Reservation>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<LoginRequest, LoginCommand>();
        }
    }
}
