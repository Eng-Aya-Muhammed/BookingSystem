using AutoMapper;
using BookingSystem.Core.DTOs.Reservation;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Queries
{
    public class GetReservationByIdQueryHandler(
     IRepository<Reservation> repository,
     IMapper mapper
 ) : IRequestHandler<GetReservationByIdQuery, ReservationDto?>
    {
        public async Task<ReservationDto?> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await repository.GetByIdAsync(request.Id);
            if (reservation == null) throw new KeyNotFoundException("Reservation not found");
            return mapper.Map<ReservationDto>(reservation);
        }
    }

}
