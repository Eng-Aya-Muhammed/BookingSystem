using AutoMapper;
using BookingSystem.Core.DTOs.Reservation;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using MediatR;
using System.Security.Claims;

namespace BookingSystem.Core.Features.Reservations.Commands
{
    public class CreateReservationCommandHandler(
        IRepository<Reservation> repository,
        IRepository<Trip> tripRepository,
        IUnitOfWork uow,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    ) : IRequestHandler<CreateReservationCommand, ReservationDto>
    {
        public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                throw new UnauthorizedAccessException("User ID not found in token.");
            }
            var trip = await tripRepository.GetByIdAsync(request.TripId);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with ID {request.TripId} not found.");
            }
            var reservation = mapper.Map<Reservation>(request);
            reservation.ReservedById = userId; 
            reservation.CreationDate = DateTime.UtcNow;

            await repository.AddAsync(reservation);
            await uow.SaveChangesAsync();

            return mapper.Map<ReservationDto>(reservation);
        }
    }
}
