using FluentValidation;
using HotelReservationApi.ViewModel.Reservations;
using HotelReservationApi.ViewModel.RoomFacilities;

namespace HotelReservationApi.Validators
{
    public class ReservationFacilityViewModelValidator : AbstractValidator<ReservationFacilityViewModel>
    {
        public ReservationFacilityViewModelValidator()
        {
            RuleFor(reservationFacility => reservationFacility.RoomId)
                .GreaterThan(0).WithMessage("The room ID must be greater than 0.");
        }
    }
}
