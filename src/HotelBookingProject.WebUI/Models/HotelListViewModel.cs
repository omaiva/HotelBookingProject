using HotelBookingProject.WebUI.DTO;

namespace HotelBookingProject.WebUI.Models
{
    public class HotelListViewModel
    {
        public IEnumerable<HotelUIDto> Hotels { get; set; }
        public IEnumerable<ImageUIDto> Images { get; set; }
    }
}
