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

        public async Task<IEnumerable<Facilities>> GetFacilities(HashSet<int> ints)
        {
            List<Facilities> facilities = new List<Facilities> { };
            foreach (var id in ints) 
            {
                Facilities facility = new Facilities();
                facility = _repository.GetByID(id);
                facilities.Add(facility);
            }
            return facilities;
            
        }

        public async Task<Facilities> GetFacilitiesById(int id)
        {
            Facilities facilities =  _repository.GetByID(id);
            return facilities;
            
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
