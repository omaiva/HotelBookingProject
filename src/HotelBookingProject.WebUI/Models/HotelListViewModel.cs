using HotelBookingProject.Domain.Entities;

namespace HotelBookingProject.WebUI.Models
{
    public class HotelListViewModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
