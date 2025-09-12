using BookingSystem.Core.DTOs;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Queries
{
    public record GetReservationByIdQuery(int Id) : IRequest<ReservationDto?> { }
}
