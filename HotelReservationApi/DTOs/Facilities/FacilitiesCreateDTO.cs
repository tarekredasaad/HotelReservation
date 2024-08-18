namespace HotelReservationApi.DTOs.Facilities
{
    public class FacilitiesCreateDTO
    {
        public List<FacilityCreateDTO> Facilities { get; set; }
    }
    public class FacilityCreateDTO
    {
        public string name { get; set; }
        public double Cost { get; set; }
    }
}
