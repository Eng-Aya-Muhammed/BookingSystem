using BookingSystem.Core.DTOs.Reservation;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    
   public record UpdateReservationWithIdCommand(
    int Id,
    UpdateReservationCommand Command
) : IRequest<ReservationDto>;

}
