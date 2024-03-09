using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Interfaces;
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

        public async Task<SelectedHotelDto> GetHotelById(int id)
        {
            var hotelEntities = await _context.Hotels.AsNoTracking().ToListAsync();

            var hotels = hotelEntities
                .Select(h => new SelectedHotelDto() { Id = h.Id, Name = h.Name, Description = h.Description, ImageId = h.ImageId, 
                CityName = _context.Cities.AsNoTracking().First(c => c.Id == h.CityId).Name,
                HouseNumber = h.HouseNumber, NumberOfFloors = h.NumberOfFloors, Street = h.Street, Latitude = h.Latitude, Longitude = h.Longitude});

            return hotels.First(h => h.Id == id);
        }

        public async Task<IEnumerable<HotelDto>> GetHotelsById(int id)
        {
            var hotelEntities = await _context.Hotels.AsNoTracking().ToListAsync();

            var hotels = hotelEntities
                .Select(h => new HotelDto() { Id = h.Id, Name = h.Name, Description = h.Description, ImageId = h.ImageId, CityId = h.CityId});

            return hotels.Where(h => h.CityId == id);
        } 

        public async Task<IEnumerable<CityDto>> GetCities()
        {
            var cityEntities = await _context.Cities.AsNoTracking().ToListAsync();

            var cities = cityEntities
                .Select(c => new CityDto() {Id = c.Id,Name = c.Name});

            return cities;
        }

        public async Task<IEnumerable<ImageDto>> GetImages()
        {
            var imageEntities = await _context.Images.AsNoTracking().ToListAsync();

            var images = imageEntities
                .Select(i => new ImageDto() { Id = i.Id, Path = i.Path});

            return images;
        }

        public async Task<IEnumerable<HotelRoomDto>> GetRoomsByHotelId(int id)
        {
            var roomEntities = await _context.HotelRooms.AsNoTracking().ToListAsync();

            var rooms = roomEntities
                .Select(r => new HotelRoomDto() { Id = r.Id, Description = r.Description, HasBath = r.HasBath, HasContidioning = r.HasContidioning,
                HasWiFi = r.HasWiFi, ImageId = r.ImageId, HotelId = r.HotelId, IsAvailable = r.IsAvailable, Name = r.Name, NumberOfBeds = r.NumberOfBeds, Price = r.Price});

            return rooms.Where(r => r.HotelId == id);
        }
            
    }
}
