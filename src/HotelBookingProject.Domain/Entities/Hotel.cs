using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}
        public int NumberOfFloors {  get; set;}
        public City HotelCity { get; set;}
        public string Street { get; set;}
        public int HouseNumber {  get; set;}

    }
}
