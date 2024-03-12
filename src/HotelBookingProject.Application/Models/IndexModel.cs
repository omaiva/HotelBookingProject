using HotelBookingProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Models
{
    public class IndexModel
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public IEnumerable<HotelDto> Hotels { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
    }
}
