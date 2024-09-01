using AutoMapper;
using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.Feedbacks;

namespace HotelReservationApi.MapperProfile
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedbackViewModel, FeedbackCreateDTO>().ReverseMap();
            CreateMap<FeedbackViewModel, FeedbackDTO>().ReverseMap();

            CreateMap<FeedbackCreateDTO, Feedback>().ReverseMap();
            CreateMap<FeedbackDTO, Feedback>().ReverseMap();
        }
    }
}
