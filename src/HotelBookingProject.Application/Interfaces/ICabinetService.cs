using HotelBookingProject.Application.DTO;

namespace HotelBookingProject.Application.Interfaces
{
    public interface ICabinetService
    {
        Task CancelBooking(int bookingId);
        Task<IEnumerable<BookingDto>> GetBookings(int userId);
    }
}