using HotelBookingProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.DTO
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        public string? RoomName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookingStatusType? Status { get; set; }
    }
}
