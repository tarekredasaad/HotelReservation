using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Services.FacilitiesSrv;

namespace HotelReservationApi.Mediator.Facilities
{
    public class FacilityMediator : IFacilityMediator
    {
        private readonly IFacilityService _facilityService;

        public FacilityMediator(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        public async Task<FacilityDTO> AddFacility(FacilityCreateDTO facilityCreateDTO)
        {
           FacilityDTO facilityDTO = await _facilityService.AddFacility(facilityCreateDTO);
            return facilityDTO;
        }

        public async Task DeleteFacilityAsync(int id)
        {
            _facilityService.RemoveFacility(id);
            await _facilityService.SaveChangesAsync();
        }

        public IEnumerable<FacilityDTO> GetFacilities()
        {
            var facilityDTOs = _facilityService.GetFacilities();
            return facilityDTOs;
        }

        public async Task<FacilityDTO> GetFacilityById(int id)
        {
            var facilityDTO = await _facilityService.GetFacilityById(id);
            return facilityDTO;
        }

        public async Task UpdateFacilityAsync(FacilityDTO facilityDTO)
        {
            _facilityService.UpdateFacility(facilityDTO);
            await _facilityService.SaveChangesAsync();
        }
    }
}
