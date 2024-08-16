using HotelReservationApi.DTOs.Facilities;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public interface IFacilitiesService
    {
        IEnumerable<FacilitiesDTO> GetFacilities();
        FacilitiesDTO GetFacilitiesById(int id);
        void AddFacility(FacilitiesCreateDTO facilitiesCreateDTO);
        void UpdateFacility(FacilitiesDTO facilitiesDTO);
        void RemoveFacility(int id);
    }
}
