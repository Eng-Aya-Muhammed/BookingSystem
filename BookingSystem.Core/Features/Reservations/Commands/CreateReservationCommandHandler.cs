using AutoMapper;
using BookingSystem.Core.DTOs;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public class CreateReservationCommandHandler(
    IRepository<Reservation> repository,
    IUnitOfWork uow,
    IMapper mapper
) : IRequestHandler<CreateReservationCommand, ReservationDto>
    {
        public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = mapper.Map<Reservation>(request);
            reservation.CreationDate = DateTime.UtcNow;

            await repository.AddAsync(reservation);
            await uow.SaveChangesAsync();

            return mapper.Map<ReservationDto>(reservation);
        }
    }
}
