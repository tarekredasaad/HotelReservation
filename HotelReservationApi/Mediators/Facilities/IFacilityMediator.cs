using HotelReservationApi.DTOs.Facilities;

namespace HotelReservationApi.Mediators.Facilities
{
    public interface IFacilityMediator
    {
        Task<FacilityDTO> AddFacility(FacilityCreateDTO facilityCreateDTO);
    }
}
