using FluentValidation;
using HotelReservationApi.ViewModels.Reports;

namespace HotelReservationApi.Validators
{
    public class RevenueReportRequestValidator : AbstractValidator<RevenueReportRequestViewModel>
    {
        public RevenueReportRequestValidator()
        {
            RuleFor(request => request.StartDate)
                .NotEmpty().WithMessage("The start date is required.")
                .LessThan(request => request.EndDate).WithMessage("The start date must be before the end date.");

            RuleFor(request => request.EndDate)
                .NotEmpty().WithMessage("End date is required.");

            RuleFor(request => request.StartDate)
                .LessThanOrEqualTo(request => request.EndDate)
                .WithMessage("Start date must be less than or equal to end date.");

            RuleFor(request => request.EndDate)
                .GreaterThanOrEqualTo(request => request.StartDate)
                .WithMessage("End date must be greater than or equal to start date.");
        }
    }
}
