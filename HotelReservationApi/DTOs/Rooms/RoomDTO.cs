using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }
        public List<IFormFile> Pictures { get; set; }
       
        public HashSet<int> Facilities { get; set; }
    }
}
