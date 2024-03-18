using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Domain.Enums;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Services
{
    public class CabinetService : ICabinetService
    {
        private readonly ProjectContext _projectContext;

        public CabinetService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task CancelBooking(int bookingId)
        {
            var roomId = _projectContext.Bookings.First(b => b.Id == bookingId).HotelRoomId;
            _projectContext.Bookings.First(b => b.Id == bookingId).BookingStatusId = (int)BookingStatusType.Canceled;

            _projectContext.HotelRooms.First(r => r.Id == roomId).IsAvailable = true;

            await _projectContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingDto>> GetBookings(int userId)
        {
            var bookingEntities = await _projectContext.Bookings.Where(b => b.UserId == userId).ToListAsync();

            var bookings = bookingEntities.Select(b => new BookingDto
            {
                Id = b.Id,
                Status = (BookingStatusType)b.BookingStatusId,
                HotelName = _projectContext.Hotels.First(h => h.Id == _projectContext.HotelRooms.First(r => r.Id == b.HotelRoomId).HotelId).Name,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                RoomName = _projectContext.HotelRooms.First(r => r.Id == b.HotelRoomId).Name
            });

            return bookings;
        }
    }
}
