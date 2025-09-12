using BookingSystem.Core.DTOs;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public record CreateReservationCommand(string CustomerName, int TripId, DateTime ReservationDate, string? Notes, int ReservedById) : IRequest<ReservationDto>;
}
