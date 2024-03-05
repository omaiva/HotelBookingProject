using HotelBookingProject.Domain.Entities;
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
        public Task<Hotel> GetHotelById(int id);
        public Task<IEnumerable<Hotel>> GetHotelsById(int id);

        public Task<IEnumerable<City>> GetCities();

        public Task<City> GetCityById(int id);

        public Task<IEnumerable<Image>> GetImages();

        public Task<IEnumerable<HotelRoom>> GetRoomsByHotelId(int id);
    }
}
