using BookingSystem.Core.DTOs.Reservation;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public record CreateReservationCommand(string CustomerName, int TripId, DateTime ReservationDate, string? Notes) : IRequest<ReservationDto>;
}
