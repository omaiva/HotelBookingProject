using HotelBookingProject.Domain.Enums;

namespace HotelBookingProject.WebUI.DTO
{
    public class BookingUIDto
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        public string? RoomName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookingStatusType? Status { get; set; }
    }
}
