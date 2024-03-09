using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.DTO
{
    public class SelectedHotelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int NumberOfFloors { get; set; }
        public string? Street { get; set; }
        public int HouseNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? CityName { get; set; }
        public int ImageId { get; set; }
    }
}
