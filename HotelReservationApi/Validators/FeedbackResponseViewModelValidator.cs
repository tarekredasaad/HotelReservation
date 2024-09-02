using FluentValidation;
using HotelReservationApi.ViewModels.FeedbackResponses;

namespace HotelReservationApi.Validators
{
    public class FeedbackResponseViewModelValidator : AbstractValidator<FeedbackResponseViewModel>
    {
        public FeedbackResponseViewModelValidator()
        {
            RuleFor(response => response.StaffId)
                .GreaterThan(0).WithMessage("Staff ID must be greater than zero.");

            RuleFor(response => response.FeedbackId)
               .GreaterThan(0).WithMessage("FeedBack ID must be greater than zero.");

            RuleFor(response => response.ResponseText)
                .NotEmpty().WithMessage("Response text is required.")
                .MaximumLength(1000).WithMessage("Response text must be less than 1000 characters.");
        }
    }
}
