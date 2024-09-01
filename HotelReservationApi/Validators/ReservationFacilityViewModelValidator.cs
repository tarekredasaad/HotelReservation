using FluentValidation;
using HotelReservationApi.ViewModels.Reservations;
using HotelReservationApi.ViewModels.RoomFacilities;

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
