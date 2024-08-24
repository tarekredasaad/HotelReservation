using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.Facilities
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _facilityRepository;

        public FacilityService(IRepository<Facility> facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<FacilityDTO> GetFacilities()
        {
            var facilities = _facilityRepository.GetAll();

            var facilityDTOs = facilities.Map<FacilityDTO>();

            return facilityDTOs;
        }

        public async Task<IEnumerable<FacilityDTO>> GetFacilities(HashSet<int> ints)
        {
            List<FacilityDTO> facilityDTOs = new List<FacilityDTO>();

            foreach (var id in ints) 
            {
                Facility facility = new Facility();
                facility = _facilityRepository.GetByID(id);
                facilityDTOs.Add(facility.MapOne<FacilityDTO>());
            }

            return facilityDTOs;
        }

        public async Task<FacilityDTO> GetFacilityById(int id)
        {
            Facility facility = _facilityRepository.GetByID(id);

            var facilityDTO = facility.MapOne<FacilityDTO>();

            return facilityDTO;
        }

        public async Task<FacilityDTO> AddFacility(FacilityCreateDTO facilityCreateDTO)
        {
            var facility = facilityCreateDTO.MapOne<Facility>();

            var result = await _facilityRepository.AddAsync(facility);

            var facilityDTO = result.MapOne<FacilityDTO>();

            return facilityDTO;
        }

        public void UpdateFacility(FacilityDTO facilityDTO)
        {
            var facility = facilityDTO.MapOne<Facility>();
            _facilityRepository.Update(facility);
        }

        public void RemoveFacility(int id)
        {
            _facilityRepository.Delete(id);
        }

        public async Task SaveChangesAsync()
        {
            await _facilityRepository.SaveChangesAsync();
        }
    }
}
