using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public record DeleteReservationCommand(int Id) : IRequest<Unit>;
}
