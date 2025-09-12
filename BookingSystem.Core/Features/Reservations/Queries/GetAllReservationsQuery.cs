using BookingSystem.Core.DTOs.Reservation;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Queries
{
    public record GetAllReservationsQuery : IRequest<IEnumerable<ReservationDto>> { }
}
