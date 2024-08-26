using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Mediator.Facilities
{
    public interface IFacilityMediator
    {
        IEnumerable<FacilityDTO> GetFacilities();
        Task<FacilityDTO> GetFacilityById(int id);
        Task<FacilityDTO> AddFacility(FacilityCreateDTO facilityCreateDTO);
        Task UpdateFacilityAsync(FacilityDTO facilityDTO);
        Task DeleteFacilityAsync(int id);
    }
}
