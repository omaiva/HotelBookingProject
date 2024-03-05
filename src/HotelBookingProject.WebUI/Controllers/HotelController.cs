using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingProject.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> SelectedHotel(int hotelId)
        {
            var model = new SelectedHotelViewMode()
            {
                Hotel = await _hotelService.GetHotelById(hotelId),
                HotelRooms = await _hotelService.GetRoomsByHotelId(hotelId),
                Images = await _hotelService.GetImages(),
                City = await _hotelService.GetCityById(hotelId)
            };

            return View(model);
        }
    }
}
