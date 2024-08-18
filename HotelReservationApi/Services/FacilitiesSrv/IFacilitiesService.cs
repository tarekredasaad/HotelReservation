using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public interface IFacilitiesService
    {
        Task<IEnumerable<Facilities>> GetFacilities(HashSet<int> ints);
        FacilitiesDTO GetFacilitiesById(int id);
        Task<ResultViewModel> AddFacility(FacilitiesCreateDTO facilitiesCreateDTO);
        void UpdateFacility(FacilitiesDTO facilitiesDTO);
        void RemoveFacility(int id);
    }
}
