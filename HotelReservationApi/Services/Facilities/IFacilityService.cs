using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.Facilities
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityDTO>> GetFacilities(HashSet<int> ints);
        Task<FacilityDTO> GetFacilityById(int id);
        Task<FacilityDTO> AddFacility(FacilityCreateDTO facilityCreateDTO);
        void UpdateFacility(FacilityDTO facilityDTO);
        void RemoveFacility(int id);
    }
}
