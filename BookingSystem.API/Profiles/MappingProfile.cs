using AutoMapper;
using BookingSystem.Core.Features.Reservations.Commands;
using BookingSystem.Core.DTOs;
using BookingSystem.Core.Models;

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
        }
    }
}
