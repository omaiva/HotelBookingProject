using HotelBookingProject.Application.DTO;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Interfaces
{
    public interface IHotelService
    {
        public Task<SelectedHotelDto> GetHotelById(int id);
        public Task<IEnumerable<HotelDto>> GetHotelsById(int id);

        public Task<IEnumerable<CityDto>> GetCities();

        public Task<IEnumerable<ImageDto>> GetImages();

        public Task<IEnumerable<HotelRoomDto>> GetRoomsByHotelId(int id);
    }
}
