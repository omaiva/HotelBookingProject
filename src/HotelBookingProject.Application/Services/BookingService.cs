using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddBooking(int userId, int roomId, DateTime startDate, DateTime endDate)
        {
            var booking = new Booking()
            {
                UserId = userId,
                HotelRoomId = roomId,
                StartDate = startDate,
                EndDate = endDate,
                BookingStatusId = 1
            };

            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingStatuses()
        {
            var today = DateTime.UtcNow.Date;
            var bookingsToUpdate = _context.Bookings
                                            .Where(b => b.EndDate < today && b.BookingStatusId == 1);

            foreach (var booking in bookingsToUpdate)
            {
                booking.BookingStatusId = 2;
            }

            await _context.SaveChangesAsync();
        }
    }
}
