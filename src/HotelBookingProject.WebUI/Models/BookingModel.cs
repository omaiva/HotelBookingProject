using HotelBookingProject.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingProject.WebUI.Models
{
    public class BookingModel
    {
        [Required]
        public int HotelRoomId { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Please, choose correct date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date,ErrorMessage = "Please, choose correct date")]
        public DateTime EndDate { get; set; }
        [Required]
        public int HotelId { get; set; }
    }
}
