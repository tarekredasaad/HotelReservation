using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public interface IFacilitiesService
    {
        IEnumerable<FacilitiesDTO> GetFacilities();
        FacilitiesDTO GetFacilitiesById(int id);
        Task<ResultViewModel> AddFacility(FacilitiesCreateDTO facilitiesCreateDTO);
        void UpdateFacility(FacilitiesDTO facilitiesDTO);
        void RemoveFacility(int id);
    }
}
