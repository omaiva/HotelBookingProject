using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly ProjectContext _context;

        public BookingService(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddBooking(int userId, int roomId, DateTime startDate, DateTime endDate)
        {
            var booking = new Booking()
            {
                UserId = userId,
                HotelRoomId = roomId,
                StartDate = startDate,
                EndDate = endDate
            };

            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
