using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Entities
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor {  get; set; }
        public int NumberOfBeds { get; set; }
        public string Description { get; set; }
        public bool HasBath {  get; set; }
        public bool HasContidioning { get; set; }
        public bool HasWiFi {  get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Booking> Bookings {  get; set; }
    }
}
