using AutoMapper;
using BookingSystem.Core.DTOs.Reservation;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Queries
{
    public class GetAllReservationsQueryHandler(
     IRepository<Reservation> repository,
     IMapper mapper) : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
    {

        public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }

}
