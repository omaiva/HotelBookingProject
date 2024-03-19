using HotelBookingProject.Domain.Enums;
using HotelBookingProject.WebUI.DTO;

namespace HotelBookingProject.WebUI.Models
{
    public class BookingsViewModel
    {
        public IEnumerable<BookingUIDto> Bookings { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? CurrentFilter { get; set; }
        public BookingStatusType? SelectedStatus { get; set; }
    }
}
