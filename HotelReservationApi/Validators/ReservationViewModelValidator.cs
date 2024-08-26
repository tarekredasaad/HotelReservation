﻿using FluentValidation;
using HotelReservationApi.ViewModel.Reservations;

namespace HotelReservationApi.Validators
{
    public class ReservationViewModelValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationViewModelValidator()
        {
            RuleFor(reservation => reservation.From)
                .NotEmpty().WithMessage("The start date is required.")
                .LessThan(reservation => reservation.To).WithMessage("The start date must be before the end date.");

            RuleFor(reservation => reservation.To)
                .NotEmpty().WithMessage("The end date is required.")
                .GreaterThan(reservation => reservation.From).WithMessage("The end date must be after the start date.");

            RuleForEach(reservation => reservation.RoomFacilities)
                .SetValidator(new RoomFacilityViewModelValidator());
        }
    }
}
