using HotelBookingProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Models
{
    public class SelectedHotelModel
    {
        public int HotelId { get; set; }
        public SelectedHotelDto Hotel { get; set; }
        public IEnumerable<HotelRoomDto> HotelRooms { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
    }
}
