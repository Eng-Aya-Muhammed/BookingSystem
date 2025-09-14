using BookingSystem.Core.Features.Reservations.Commands;
using FluentValidation;

namespace BookingSystem.Core.Features.Reservations.Validators
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.CustomerName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.");

            RuleFor(x => x.TripId)
                .GreaterThan(0).WithMessage("Trip Id must be greater than zero.");

            RuleFor(x => x.ReservationDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("Reservation date must be in the future.");
        }
    }

}
