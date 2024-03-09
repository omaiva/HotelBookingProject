using HotelBookingProject.Domain.Entities;
using HotelBookingProject.WebUI.DTO;

namespace HotelBookingProject.WebUI.Models
{
    public class SelectedHotelViewModel
    {
        public int HotelId { get; set; }
        public SelectedHotelUIDto Hotel { get; set; }
        public IEnumerable<HotelRoomUIDto> HotelRooms { get; set; }
        public IEnumerable<ImageUIDto> Images { get; set; }
    }
}
