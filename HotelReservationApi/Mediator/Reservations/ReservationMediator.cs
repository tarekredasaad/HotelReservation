using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.Services.RoomFacilitySrv;
using HotelReservationApi.Services.RoomReservationSrv;
using HotelReservationApi.ViewModel;
using HotelReservationApi.Constant.Enum;
using Stripe.Checkout;
using Stripe;
using HotelReservationApi.Services.InvoiceSrv;

namespace HotelReservationApi.Mediator.Reservations
{
    public class ReservationMediator : IReservationMediator
    {
        IReservationService _reservationService;
        IRoomReservationService _roomReservationService;
        IRoomFacilityService _roomFacilityService;
        IInvoiceService _invoiceService;
        public ReservationMediator(IReservationService reservationService
            , IRoomReservationService roomReservationService
            ,IRoomFacilityService roomFacilityService
            ,IInvoiceService invoice)
        {
            _reservationService = reservationService;
            _roomReservationService = roomReservationService;
            _roomFacilityService = roomFacilityService;
            _invoiceService = invoice;
        }

        public async Task<ResultViewModel> AddReservation(ReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return ResultViewModel.Faliure();
            }

            //Reservation reservation = await _reservationService.AddReservation(reservationDTO);
            Reservation reservation = new Reservation();
            reservation = await _reservationService
                .AddReservation(reservationDTO);

            reservation.TotalPrice = await  _roomFacilityService
                .costRoom(reservationDTO.roomFacilityDTOs);
            //await _reservationService.SaveChange(reservation);
            RoomReservation roomReservation = new RoomReservation();
            roomReservation.ReservationId = reservation.Id;

            RoomReservationDTO roomReservationDTO = new RoomReservationDTO();
            //roomReservationDTO = reservation.MapOne<RoomReservationDTO>();
            roomReservationDTO = reservationDTO.MapOne<RoomReservationDTO>();
            roomReservationDTO.Reservation = reservation;
            roomReservationDTO.RoomFacilityDTO = reservationDTO.roomFacilityDTOs;
            List<RoomReservation> roomReservations = await _roomReservationService
                .AddRoomReservation(roomReservationDTO);

            return ResultViewModel.Sucess(roomReservations);

        }
        public async Task<string> CreateCheckOut(ConfirmReservationDTO confirmReservationDTO)
        {
            int id = confirmReservationDTO.reservationId;
            long amount = confirmReservationDTO.Amount;

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(confirmReservationDTO.Amount * 100),
                Currency = "usd",
                PaymentMethod = "pm_card_visa",

            };  //_stripeSettings.SecretKey;//
            StripeConfiguration.ApiKey = "sk_test_51PqW8S01MqAl9mk4G6qYv1fym30xCJqVD8RhU3ZUGV9fd8WVw9L6sWM1RbmxIpUI9jPyL63KykSr8S3gsKankoL900CmF3Bs1W";
            var service = new PaymentIntentService();
            PaymentIntent response = service.Create(options);
            PaymentMethod paymentMethod = new PaymentMethod();
            var optionsCheckout = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = response.Currency,
                            UnitAmount = response.Amount,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = " H23",
                                Description = " Room in Global Hotel 5 star"
                            }

                        },
                        Quantity = 1

                    }

                },

                Mode = "payment",
                SuccessUrl = $"https://localhost:44364/api/Reservation/getReservation?reservationId={id}&Amount={amount}",
                CancelUrl = "https://localhost:5255/"
            };
            var SussionService = new SessionService();
            var session = SussionService.Create(optionsCheckout);
            return session.Url;
        }
        public async Task<ResultViewModel> ConfirmReservation(ConfirmReservationDTO confirmReservationDTO)
        {
            if (confirmReservationDTO == null)
            {
                return null;
            }
            Reservation reservation = await _reservationService.Get(confirmReservationDTO.reservationId);
           
            reservation.IsConfirmed = true;
            reservation = await _reservationService.Update(reservation);

            Models.Invoice invoice = new Models.Invoice();
            invoice.ReservationId = reservation.Id;
            invoice.Amount =(double) confirmReservationDTO.Amount;
            invoice.InvoiceDate = DateTime.Now;
            invoice.PaymentStatus = PaymentStatus.Paid;
            invoice.PaymentType = PaymentType.cash;
            invoice = await _invoiceService.AddInvoice(invoice);


            return ResultViewModel.Sucess(reservation);
        }
    }
}
