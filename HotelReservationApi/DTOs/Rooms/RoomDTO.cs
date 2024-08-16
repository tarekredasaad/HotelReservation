using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Models;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public double Price { get; set; }
        public HashSet<PicturesCreateDTO> Pictures { get; set; }
        public HashSet<FacilitiesCreateDTO> Facilities { get; set; }

    }
}
