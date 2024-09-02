using FluentValidation;
using HotelReservationApi.Mediators.Reports;
using HotelReservationApi.ViewModels.Feedbacks;
using HotelReservationApi.ViewModels;
using HotelReservationApi.ViewModels.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using HotelReservationApi.Helper;
using HotelReservationApi.DTOs.Reports;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportMediator _reportMediator;
        private readonly IValidator<RevenueReportRequestViewModel> _revenueReportValidator;

        public ReportController(IReportMediator reportMediator, IValidator<RevenueReportRequestViewModel> validator)
        {
            _reportMediator = reportMediator;
            _revenueReportValidator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<RevenueReportViewModel>> GetRevenueReport(RevenueReportRequestViewModel revenueRequestVM)
        {
            ValidationResult valdiationResult = _revenueReportValidator.Validate(revenueRequestVM);

            if (!valdiationResult.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(valdiationResult.Errors.First().ToString()));
            }

            var mediatorResult = await _reportMediator.GetRevenueReportAsync(revenueRequestVM.StartDate, revenueRequestVM.EndDate);

            if (!mediatorResult.IsSuccess)
            {
                return BadRequest(ResultViewModel.Faliure(mediatorResult.Message));
            }

            var revenueReportViewModel = mediatorResult.Data.MapOne<RevenueReportDTO>();

            return Ok(ResultViewModel.Sucess(revenueReportViewModel));
        }

        [HttpGet]
        public async Task<ActionResult<CustomerReportViewModel>> GetCustomerReport(int customerId)
        {
            if (customerId == 0) 
            {
                return BadRequest(ResultViewModel.Faliure("Customer ID must be greater than 0."));
            }

            var mediatorResult = await _reportMediator.GetCustomerReportAsync(customerId);

            if (!mediatorResult.IsSuccess)
            {
                return BadRequest(ResultViewModel.Faliure(mediatorResult.Message));
            }

            return Ok(ResultViewModel.Sucess(mediatorResult));
        }
    }
}
