using FluentValidation;
using HotelReservationApi.Models;

namespace HotelReservationApi.Validators
{
    public class RoomReservationValidator : AbstractValidator<RoomReservation>
    {
        public RoomReservationValidator()
        {
            RuleFor(rs => rs.RoomId).NotEmpty().WithMessage("Room ID is requird.");
        }
    }
}
