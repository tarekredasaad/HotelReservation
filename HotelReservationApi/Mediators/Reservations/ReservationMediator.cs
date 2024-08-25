using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Services.Facilities;
using HotelReservationApi.Services.Payments;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.Services.Rooms;

namespace HotelReservationApi.Mediators.Reservations
{
    public class ReservationMediator : IReservationMediator
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IFacilityService _facilityService;
        private readonly IPaymentService _paymentService;

        public ReservationMediator(IReservationService reservationService, 
            IRoomService roomService, 
            IFacilityService facilityService, 
            IPaymentService paymentService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _facilityService = facilityService;
            _paymentService = paymentService;
        }

        public async Task<ReservationDTO> AddReservation(ReservationCreateDTO reservationCreateDTO)
        {
            double totalAmount = await CalculateTotalAmount(reservationCreateDTO);

            string paymentIntentId = await _paymentService.CreatePaymentIntent(totalAmount);

            ReservationDTO reservationDTO = new ReservationDTO
            {
                TotalAmount = totalAmount,
                PaymentIntentId = paymentIntentId,
                PaymentStatus = PaymentStatus.Pending
            };

            reservationDTO  = await _reservationService.AddReservation(reservationDTO);
            
            return reservationDTO;
        }

        public bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            bool isAvailable = _reservationService.IsRoomAvailable(roomId, checkInDate, checkOutDate);

            return isAvailable;
        }

        private async Task<double> CalculateTotalAmount(ReservationCreateDTO reservationCreateDTO)
        {
            double totalAmount = 0;
            int numberOfDays = (reservationCreateDTO.CheckOutDate - reservationCreateDTO.CheckInDate).Days;

            foreach (var roomReservation in reservationCreateDTO.RoomReservations)
            {
                var roomDTO = _roomService.GetRoomById(roomReservation.RoomId);

                if (roomDTO is not null)
                {
                    totalAmount += roomDTO.Price * numberOfDays;
                }

                foreach (var facilityId in roomReservation.FacilityIDs)
                {
                    var facility = await _facilityService.GetFacilityById(facilityId);

                    if (facility is not null)
                    {
                        totalAmount += facility.Cost;
                    }
                }
            }

            return totalAmount;
        }
    }
}
