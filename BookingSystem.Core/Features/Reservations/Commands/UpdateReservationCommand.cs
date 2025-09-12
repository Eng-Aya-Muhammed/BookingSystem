using BookingSystem.Core.DTOs;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public record UpdateReservationCommand(int Id, string? CustomerName, int? TripId, DateTime? ReservationDate, string? Notes) : IRequest<ReservationDto>;
}
