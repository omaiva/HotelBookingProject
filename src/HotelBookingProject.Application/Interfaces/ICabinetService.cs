using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Filters;

namespace HotelBookingProject.Application.Interfaces
{
    public interface ICabinetService
    {
        Task CancelBooking(int bookingId);
        Task<IEnumerable<BookingDto>> GetBookings(int userId, BookingFilter filter);
        Task<int> GetTotalBookingsCount(int userId, BookingFilter filter);
    }
}