﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}
        public int NumberOfFloors {  get; set;}
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string Street { get; set;}
        public int HouseNumber {  get; set;}
        public virtual List<HotelRoom> HotelRooms { get; set; }
    }
}
