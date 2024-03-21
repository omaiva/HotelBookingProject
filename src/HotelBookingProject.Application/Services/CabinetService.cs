using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Filters;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Application.Models;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Domain.Enums;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public CabinetService(ProjectContext projectContext, UserManager<User> userManager)
        {
            _projectContext = projectContext;
            _userManager = userManager;
        }

        public async Task CancelBooking(int bookingId)
        {
            var roomId = _projectContext.Bookings.First(b => b.Id == bookingId).HotelRoomId;
            _projectContext.Bookings.First(b => b.Id == bookingId).BookingStatusId = (int)BookingStatusType.Canceled;

            _projectContext.HotelRooms.First(r => r.Id == roomId).IsAvailable = true;

            await _projectContext.SaveChangesAsync();
        }

        public async Task<int> GetTotalBookingsCount(int userId, BookingFilter filter)
        {
            var query = _projectContext.Bookings.AsQueryable().Where(b => b.UserId == userId);

            if (filter.CurrentFilter != null)
            {
                query = from b in query
                        join hr in _projectContext.HotelRooms on b.HotelRoomId equals hr.Id
                        join h in _projectContext.Hotels on hr.HotelId equals h.Id
                        where h.Name.Contains(filter.CurrentFilter)
                        select b;
            }

            if (filter.SelectedStatus.HasValue)
            {
                query = query.Where(b => b.BookingStatusId == (int)filter.SelectedStatus.Value);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<BookingDto>> GetBookings(int userId, BookingFilter filter)
        {
            var query = _projectContext.Bookings.AsQueryable().Where(b => b.UserId == userId);

            if(filter.CurrentFilter != null)
            {
                query = from b in query
                        join hr in _projectContext.HotelRooms on b.HotelRoomId equals hr.Id
                        join h in _projectContext.Hotels on hr.HotelId equals h.Id
                        where h.Name.Contains(filter.CurrentFilter)
                        select b;
            }

            if (filter.SelectedStatus.HasValue)
            {
                query = query.Where(b => b.BookingStatusId == (int)filter.SelectedStatus.Value);
            }

            var skipAmount = (filter.PageNumber - 1) * filter.PageSize;
            var paginatedQuery = query.Skip(skipAmount).Take(filter.PageSize);

            var bookingEntities = await paginatedQuery.ToListAsync();

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

        public async Task ChangeFirstName(int userId, string firstName)
        {
            _projectContext.Users.First(u => u.Id == userId).FirstName = firstName;

            await _projectContext.SaveChangesAsync();
        }

        public async Task ChangeLastName(int userId, string lastName)
        {
            _projectContext.Users.First(u => u.Id == userId).LastName = lastName;

            await _projectContext.SaveChangesAsync();
        }

        public async Task<SettingsModel> GetSettingsModel(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("User not found"); 
            }

            return new SettingsModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
