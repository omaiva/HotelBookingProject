using HotelBookingProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Entities
{
    public class BookingStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
