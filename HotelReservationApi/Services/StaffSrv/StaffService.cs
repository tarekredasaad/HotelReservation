using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
using HotelReservationApi.Services.StaffSrv;

namespace HotelReservationApi.Services.Staffsrv
{
    public class StaffService : IStaffService
    {
        IRepository<Staff> _StaffRepo;
        public StaffService(IRepository<Staff> _staffRepo)
        {
            _StaffRepo = _staffRepo;
        }

        public async Task AddStaff(StaffDTO  staffDTO)
        {
            

            Staff staff = staffDTO.MapOne<Staff>(); 
            staff = await  _StaffRepo.AddAsync(staff);


        }
    }
}
