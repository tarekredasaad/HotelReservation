using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Services;
using HotelReservationApi.Services.Invoices;
using HotelReservationApi.Services.Reservations;
using HotelReservationApi.Services.RoomFacilities;
using HotelReservationApi.Services.RoomReservationFacilities;
using HotelReservationApi.Services.RoomReservations;
using HotelReservationApi.Services.Rooms;
using HotelReservationApi.Services.Users;
using Stripe;
using Stripe.Checkout;
using Invoice = HotelReservationApi.Models.Invoice;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;
using SessionService = Stripe.Checkout.SessionService;

namespace HotelReservationApi.Mediator.Reservations
{
    public class ReservationMediator : IReservationMediator
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomReservationService _roomReservationService;
        private readonly IRoomFacilityService _roomFacilityService;
        private readonly IInvoiceService _invoiceService;
        IRoomReservationFacilityService _roomReservationFacilityService;
        IRoomService _roomService;
        IUserService _userService;

        public ReservationMediator(IReservationService reservationService,
            IRoomReservationService roomReservationService,
            IRoomFacilityService roomFacilityService,
            IInvoiceService invoiceService,
            IUserService userService
            , IRoomReservationFacilityService roomReservationFacilityService
            , IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomReservationService = roomReservationService;
            _roomFacilityService = roomFacilityService;
            _invoiceService = invoiceService;
            _roomService = roomService;
            _userService = userService;
            _roomReservationFacilityService = roomReservationFacilityService;
        }

        public async Task<ReservationDTO> AddReservation(ReservationDTO reservationDTO)
        {
            
            Reservation reservation = new Reservation();
            reservation.CustomerId = await _userService.GetUserIdFromToken(TokenGenerator.token);

            reservation = await _reservationService.AddReservation(reservationDTO);
            await _reservationService.SaveChangesAsync();

            reservation.TotalPrice = await _roomFacilityService.CostRoom(reservationDTO.ReservationFacilities);

            RoomReservation roomReservation = new RoomReservation();
            roomReservation.ReservationId = reservation.Id;

            RoomReservationDTO roomReservationDTO = new RoomReservationDTO();
            roomReservationDTO.Reservation = reservation;
            //roomReservationDTO.ReservationFacilityDTO = reservationDTO.ReservationFacilities;

            List<RoomReservation> roomReservations = await _roomReservationService
                .AddRoomReservation(roomReservationDTO);
            List<RoomReservationFacility> roomReservationFacilities =
              await _roomReservationFacilityService
              .Add(roomReservations, reservationDTO.ReservationFacilities);

            return reservationDTO;
        }

        public async Task<string> CreateCheckOut(ReservationConfirmDTO confirmReservationDTO)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(confirmReservationDTO.Amount * 100),
                Currency = "usd",
                PaymentMethod = "pm_card_visa",

            };

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
                SuccessUrl = $"https://localhost:44364/api/Reservation/getReservation?reservationId={confirmReservationDTO.ReservationId}&Amount={confirmReservationDTO.Amount}",
                CancelUrl = "https://localhost:5255/"
            };

            var sessionService = new SessionService();
            var session = sessionService.Create(optionsCheckout);

            return session.Url;
        }

        public async Task<ReservationDTO> ConfirmReservation(ReservationConfirmDTO confirmReservationDTO)
        {
            Reservation reservation = await _reservationService.Get(confirmReservationDTO.ReservationId);
            reservation.IsConfirmed = true;
            reservation = await _reservationService.Update(reservation);

            await CreateInvoice(reservation);

            var reservationDTO = reservation.MapOne<ReservationDTO>();

            return reservationDTO;
        }

        public async Task<List<Room>> GetAvailableRooms(SearchReservationDTO searchReservationDTO)
        {
            if (searchReservationDTO == null)
            {
                return default;
            }


            List<RoomReservation> roomReservations = await _roomReservationService.getRooms();
            List<Reservation> reservations = await _reservationService.GetReservationAvailable(searchReservationDTO);
            var reservationIds = reservations.Select(r => r.Id).ToList();
            List<Room> rooms = roomReservations
                .Where(rr => !reservationIds.Contains(rr.ReservationId))
                .Select(rr => rr.Room)
                .ToList();

            return rooms;
        }
        private async Task CreateInvoice(Reservation reservation)
        {
            Invoice invoice = new Invoice
            {
                ReservationId = reservation.Id,
                Amount = reservation.TotalPrice,
                InvoiceDate = DateTime.Now,
                PaymentStatus = PaymentStatus.Succeeded,
                PaymentType = PaymentType.Cash,
            };

            await _invoiceService.AddInvoice(invoice);
        }
    }
}