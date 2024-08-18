namespace HotelReservationApi.DTOs.Facilities
{
    public class FacilitiesCreateDTO
    {
        public List<FacilityCreateDTO> Facilities { get; set; }
    }
    public class FacilityCreateDTO
    {
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
