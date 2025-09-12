using BookingSystem.Core.DTOs.Reservation;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public record UpdateReservationCommand(int Id, string CustomerName, DateTime ReservationDate, string? Notes)
        : IRequest<ReservationDto>;
}
