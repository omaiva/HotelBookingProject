using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using HotelBookingProject.Domain.Entities;

namespace HotelBookingProject.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IBookingService _bookingService;

        public HotelController(IHotelService hotelService, IBookingService bookingService)
        {
            _hotelService = hotelService;
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> SelectedHotel(int hotelId)
        {
            var hotelModel = new SelectedHotelViewModel()
            {
                HotelId = hotelId,
                Hotel = await _hotelService.GetHotelById(hotelId),
                HotelRooms = await _hotelService.GetRoomsByHotelId(hotelId),
                Images = await _hotelService.GetImages(),
                City = await _hotelService.GetCityById(hotelId)
            };

            ViewBag.Hotel = hotelModel;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SelectedHotel(BookingModel model)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (ModelState.IsValid)
            {
                await _bookingService.AddBooking(userId, model.HotelRoomId, model.StartDate, model.EndDate);
                TempData["BookingSuccess"] = "true";
                return Json(new { success = true, message = "Booking successful!" });
            }

            var hotelId = model.HotelId;

            var hotelModel = new SelectedHotelViewModel()
            {
                HotelId = hotelId,
                Hotel = await _hotelService.GetHotelById(hotelId),
                HotelRooms = await _hotelService.GetRoomsByHotelId(hotelId),
                Images = await _hotelService.GetImages(),
                City = await _hotelService.GetCityById(hotelId)
            };

            ViewBag.Hotel = hotelModel;

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors = errors });
        }
    }
}
