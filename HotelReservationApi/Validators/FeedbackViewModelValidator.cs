using FluentValidation;
using HotelReservationApi.ViewModels.Feedbacks;

namespace HotelReservationApi.Validators
{
    public class FeedbackViewModelValidator : AbstractValidator<FeedbackViewModel>
    {
        public FeedbackViewModelValidator()
        {
            RuleFor(feedback => feedback.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

            RuleFor(feedback => feedback.ReservationId)
                .GreaterThan(0).WithMessage("Reservation ID must be greater than zero.");

            RuleFor(feedback => feedback.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(feedback => feedback.Comments)
                .NotEmpty().WithMessage("Comments are required.")
                .MaximumLength(1000).WithMessage("Comments must be less than 1000 characters.");
        }
    }
}
