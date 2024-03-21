using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Filters;
using HotelBookingProject.Application.Models;

namespace HotelBookingProject.Application.Interfaces
{
    public interface ICabinetService
    {
        Task CancelBooking(int bookingId);
        Task ChangeFirstName(int userId, string firstName);
        Task ChangeLastName(int userId, string lastName);
        Task<IEnumerable<BookingDto>> GetBookings(int userId, BookingFilter filter);
        Task<SettingsModel> GetSettingsModel(int userId);
        Task<int> GetTotalBookingsCount(int userId, BookingFilter filter);
    }
}