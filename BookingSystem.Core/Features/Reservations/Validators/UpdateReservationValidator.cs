using BookingSystem.Core.Features.Reservations.Commands;
using FluentValidation;

namespace BookingSystem.Core.Features.Reservations.Validators
{
    public class UpdateReservationValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name is required.")
                .MaximumLength(100)
                .WithMessage("Customer name must not exceed 100 characters.");

            RuleFor(x => x.ReservationDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Reservation date must be in the future.");

            
        }
    }

}
