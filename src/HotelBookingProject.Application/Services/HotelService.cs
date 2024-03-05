﻿using System;
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

        public async Task<Hotel> GetHotelById(int id) =>
             await _context.Hotels.Where(h => h.Id == id).FirstAsync();

        public async Task<IEnumerable<Hotel>> GetHotelsById(int id) =>
            await _context.Hotels.Where(h => h.CityId == id).ToListAsync();

        public async Task<IEnumerable<City>> GetCities() =>
             await _context.Cities.ToListAsync();

        public async Task<City> GetCityById(int id) =>
            await _context.Cities.Where(c => c.Id == id).FirstAsync();

        public async Task<IEnumerable<Image>> GetImages() =>
             await _context.Images.ToListAsync();

        public async Task<IEnumerable<HotelRoom>> GetRoomsByHotelId(int id) =>
            await _context.HotelRooms.Where(r => r.HotelId == id).ToListAsync();
    }
}
