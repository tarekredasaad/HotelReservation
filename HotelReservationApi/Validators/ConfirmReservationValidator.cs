using FluentValidation;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.ViewModel.Reservations;

namespace HotelReservationApi.Validators
{
    public class ConfirmReservationValidator : AbstractValidator<ConfirmReservationDTO>
    {
        public ConfirmReservationValidator()
        {
            RuleFor(confirmReservation => confirmReservation.ReservationId)
                .NotEmpty().WithMessage("The reservation ID is required.");

            RuleFor(confirmReservation => confirmReservation.Amount)
                .NotEmpty().WithMessage("The amount is required.")
                .GreaterThan(0).WithMessage("The Amount must be greater than 0.");
        }
    }
}
