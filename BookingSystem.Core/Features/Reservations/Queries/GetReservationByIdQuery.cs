using BookingSystem.Core.DTOs.Reservation;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Queries
{
    public record GetReservationByIdQuery(int Id) : IRequest<ReservationDto?> { }
}
