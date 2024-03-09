using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.DTO
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }
        public int CityId { get; set; }
    }
}
