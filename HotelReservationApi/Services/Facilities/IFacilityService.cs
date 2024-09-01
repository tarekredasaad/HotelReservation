using HotelReservationApi.DTOs.Facilities;

namespace HotelReservationApi.Services.Facilities
{
    public interface IFacilityService
    {
        IEnumerable<FacilityDTO> GetFacilities();
        Task<IEnumerable<FacilityDTO>> GetFacilities(HashSet<int> ints);
        Task<FacilityDTO> GetFacilityById(int id);
        Task<FacilityDTO> AddFacility(FacilityCreateDTO facilityCreateDTO);
        void UpdateFacility(FacilityDTO facilityDTO);
        void RemoveFacility(int id);
        Task SaveChangesAsync();
    }
}
