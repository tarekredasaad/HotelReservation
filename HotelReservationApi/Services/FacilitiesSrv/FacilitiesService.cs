using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IRepository<Facility> _repository;

        public FacilitiesService(IRepository<Facility> repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> AddFacility(FacilitiesCreateDTO facilitiesCreateDTO)
        {
            if (facilitiesCreateDTO.Facilities == null)
            {
                return ResultViewModel.Faliure();
            }
            List<Facility> facilities = new List<Facility>();
            foreach (var facility in facilitiesCreateDTO.Facilities)
            {
                Facility Facility = new Facility();
                Facility = facility.MapOne<Facility>();
                facilities.Add(Facility);
            }
            await _repository.AddRange(facilities);

            return ResultViewModel.Sucess(facilities);
            
        }

        public async Task<IEnumerable<Facility>> GetFacilities(HashSet<int> ints)
        {
            List<Facility> facilities = new List<Facility> { };
            foreach (var id in ints) 
            {
                Facility facility = new Facility();
                facility = _repository.GetByID(id);
                facilities.Add(facility);
            }
            return facilities;
            
        }

        public async Task<Facility> GetFacilitiesById(int id)
        {
            Facility facilities =  _repository.GetByID(id);
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
