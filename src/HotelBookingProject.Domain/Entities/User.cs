using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }     
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
