using HotelBookingProject.Domain.Entities;

namespace HotelBookingProject.WebUI.Models
{
    public class SelectedHotelViewModel
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public IEnumerable<HotelRoom> HotelRooms { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public City City { get; set; }
    }
}
