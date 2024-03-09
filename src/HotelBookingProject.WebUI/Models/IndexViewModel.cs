using HotelBookingProject.WebUI.DTO;

namespace HotelBookingProject.WebUI.Models
{
    public class IndexViewModel
    {
        public IEnumerable<CityUIDto> Cities { get; set; }
        public IEnumerable<HotelUIDto> Hotels { get; set; }
        public IEnumerable<ImageUIDto> Images { get; set; }
    }
}
