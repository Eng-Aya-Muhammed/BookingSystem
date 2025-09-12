using BookingSystem.Core.Features.Reservations.Commands;
using FluentValidation;

namespace BookingSystem.Core.Features.Reservations.Validators
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.TripId).GreaterThan(0);
            RuleFor(x => x.ReservationDate).GreaterThan(DateTime.UtcNow);
        }
    }
}
