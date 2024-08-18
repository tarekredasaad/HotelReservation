using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IRepository<Facilities> _repository;

        public FacilitiesService(IRepository<Facilities> repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> AddFacility(FacilitiesCreateDTO facilitiesCreateDTO)
        {
            if (facilitiesCreateDTO.Facilities == null)
            {
                return ResultViewModel.Faliure();
            }
            List<Facilities> facilities = new List<Facilities>();
            foreach (var facility in facilitiesCreateDTO.Facilities)
            {
                Facilities Facility = new Facilities();
                Facility = facility.MapOne<Facilities>();
                facilities.Add(Facility);
            }
            await _repository.AddRange(facilities);

            return ResultViewModel.Sucess(facilities);
            
        }

        public IEnumerable<FacilitiesDTO> GetFacilities()
        {
            throw new NotImplementedException();
        }

        public FacilitiesDTO GetFacilitiesById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveFacility(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateFacility(FacilitiesDTO facilitiesDTO)
        {
            throw new NotImplementedException();
        }
    }
}
