using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IRepository<Facilities> _repository;

        public FacilitiesService(IRepository<Facilities> repository)
        {
            _repository = repository;
        }

        public void AddFacility(FacilitiesCreateDTO facilitiesCreateDTO)
        {
            throw new NotImplementedException();
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
