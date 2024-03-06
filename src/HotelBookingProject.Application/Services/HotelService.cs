using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingProject.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly ProjectContext _context;

        public HotelService(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var hotels = await _context.Hotels.AsNoTracking().ToListAsync();

            return hotels.First(h => h.Id == id);
        }
             

        public async Task<IEnumerable<Hotel>> GetHotelsById(int id)
        {
            var hotels = await _context.Hotels.AsNoTracking().ToListAsync(); 

            return hotels.Where(h => h.CityId == id);
        }
            

        public async Task<IEnumerable<City>> GetCities()
        {
            var cities = await _context.Cities.AsNoTracking().ToListAsync();

            return cities;
        }
             

        public async Task<City> GetCityById(int id)
        {
            var cities = await _context.Cities.AsNoTracking().ToListAsync();

            return cities.First(c => c.Id == id);
        }

        public async Task<IEnumerable<Image>> GetImages()
        {
            var images = await _context.Images.AsNoTracking().ToListAsync();

            return images;
        }

        public async Task<IEnumerable<HotelRoom>> GetRoomsByHotelId(int id)
        {
            var rooms = await _context.HotelRooms.AsNoTracking().ToListAsync();

            return rooms.Where(r => r.HotelId == id);
        }
            
    }
}
