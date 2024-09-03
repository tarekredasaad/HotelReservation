using HotelReservationApi.DTOs.Users;

namespace HotelReservationApi.Services.StaffSrv
{
    public interface IStaffService
    {
        Task AddStaff(StaffDTO staffDTO);
    }
}
