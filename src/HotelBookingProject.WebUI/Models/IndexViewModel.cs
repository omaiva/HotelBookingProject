using HotelBookingProject.Domain.Entities;

namespace HotelBookingProject.WebUI.Models
{
    public class IndexViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; }
    }
}
