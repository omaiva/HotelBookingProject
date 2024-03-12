using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Application.Models;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingProject.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly ProjectContext _context;
        private readonly IMapper _mapper;

        public HotelService(ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IndexModel> GetDataForIndex(int id)
        {
            var cityEntities = await _context.Cities.AsNoTracking().ToListAsync();
            var hotelEntities = await _context.Hotels.AsNoTracking().Where(h => h.CityId == id).ToListAsync();
            var imageEntities = await _context.Images.AsNoTracking().ToListAsync();

            var cities = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
            var hotels = _mapper.Map<IEnumerable<HotelDto>>(hotelEntities);
            var images = _mapper.Map<IEnumerable<ImageDto>>(imageEntities);

            var model = new IndexModel() { Cities = cities, Hotels = hotels, Images = images };

            return model;
        }

        public async Task<HotelListModel> GetDataForHotelList(int id)
        {
            var hotelEntities = await _context.Hotels.AsNoTracking().Where(h => h.CityId == id).ToListAsync();
            var imageEntities = await _context.Images.AsNoTracking().ToListAsync();

            var hotels = _mapper.Map<IEnumerable<HotelDto>>(hotelEntities);
            var images = _mapper.Map<IEnumerable<ImageDto>>(imageEntities);

            var model = new HotelListModel() { Hotels = hotels, Images = images };

            return model;
        }

        public async Task<SelectedHotelModel> GetDataForSelectedHotel(int id)
        {
            var hotelEntity = await _context.Hotels.AsNoTracking().FirstAsync(h => h.Id == id);
            var roomEntities = await _context.HotelRooms.AsNoTracking().Where(r => r.HotelId == id).ToListAsync();
            var imageEntities = await _context.Images.AsNoTracking().ToListAsync();

            var hotel = _mapper.Map<SelectedHotelDto>(hotelEntity);
            hotel.CityName = _context.Cities.AsNoTracking().First(c => c.Id == hotelEntity.CityId).Name;

            var rooms = _mapper.Map<IEnumerable<HotelRoomDto>>(roomEntities);
            var images = _mapper.Map<IEnumerable<ImageDto>>(imageEntities);

            var model = new SelectedHotelModel() { HotelId = id, Hotel = hotel, HotelRooms = rooms, Images = images };

            return model;
        } 
    }
}
