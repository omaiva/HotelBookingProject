using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
