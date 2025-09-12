using AutoMapper;
using BookingSystem.Core.DTOs;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using MediatR;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public class UpdateReservationCommandHandler(
    IRepository<Reservation> repository,
    IUnitOfWork uow,
    IMapper mapper
) : IRequestHandler<UpdateReservationCommand, ReservationDto>
    {
        public async Task<ReservationDto> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await repository.GetByIdAsync(request.Id)
                              ?? throw new KeyNotFoundException("Reservation not found");

            mapper.Map(request, reservation);
            await repository.UpdateAsync(reservation);
            await uow.SaveChangesAsync();

            return mapper.Map<ReservationDto>(reservation);
        }
    }
}