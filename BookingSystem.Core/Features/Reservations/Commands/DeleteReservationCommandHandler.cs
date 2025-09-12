using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public class DeleteReservationCommandHandler(
    IRepository<Reservation> repository,
    IUnitOfWork uow) : IRequestHandler<DeleteReservationCommand, Unit>

    {
        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
            await uow.SaveChangesAsync();
            return Unit.Value;
        }
    }

}
