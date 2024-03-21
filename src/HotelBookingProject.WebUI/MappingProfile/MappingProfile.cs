using AutoMapper;
using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Models;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.WebUI.DTO;
using HotelBookingProject.WebUI.Models;

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
            CreateMap<BookingDto, BookingUIDto>();

            CreateMap<IndexModel,IndexViewModel>();
            CreateMap<HotelListModel, HotelListViewModel>();
            CreateMap<SelectedHotelModel, SelectedHotelViewModel>();
            CreateMap<SettingsModel, SettingsViewModel>();

            CreateMap<City, CityDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelRoom, HotelRoomDto>();
            CreateMap<Hotel, SelectedHotelDto>();
        }
    }
}
