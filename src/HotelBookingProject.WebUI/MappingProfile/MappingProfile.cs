using AutoMapper;
using HotelBookingProject.Application.DTO;
using HotelBookingProject.WebUI.DTO;

namespace HotelBookingProject.WebUI.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CityDto, CityUIDto>();
            CreateMap<HotelDto, HotelUIDto>();
            CreateMap<ImageDto, ImageUIDto>();
            CreateMap<SelectedHotelDto, SelectedHotelUIDto>();
            CreateMap<HotelRoomDto, HotelRoomUIDto>();
        }
    }
}
