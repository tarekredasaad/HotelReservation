using FluentValidation;
using HotelReservationApi.ViewModel.RoomFacilities;

namespace HotelReservationApi.Validators
{
    public class RoomFacilityViewModelValidator : AbstractValidator<RoomFacilityViewModel>
    {
        public RoomFacilityViewModelValidator()
        {
            RuleFor(roomFacility => roomFacility.RoomId)
                .GreaterThan(0).WithMessage("The room ID must be greater than 0.");

            RuleFor(roomFacility => roomFacility.FacilityId)
                .GreaterThan(0).WithMessage("The facility ID must be greater than 0.");
        }
    }
}
