using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.WebUI.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace HotelBookingProject.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IBookingService bookingService, IMapper mapper)
        {
            _hotelService = hotelService;
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SelectedHotel(int hotelId)
        {
            var hotel = await _hotelService.GetHotelById(hotelId);
            var images = await _hotelService.GetImages();
            var hotelRooms = await _hotelService.GetRoomsByHotelId(hotelId);

            var hotelModel = new SelectedHotelViewModel()
            {
                HotelId = hotelId,
                Hotel = _mapper.Map<SelectedHotelUIDto>(hotel),
                HotelRooms = _mapper.Map<IEnumerable<HotelRoomUIDto>>(hotelRooms),
                Images = _mapper.Map<IEnumerable<ImageUIDto>>(images)
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
            var hotel = await _hotelService.GetHotelById(hotelId);
            var images = await _hotelService.GetImages();
            var hotelRooms = await _hotelService.GetRoomsByHotelId(hotelId);

            var hotelModel = new SelectedHotelViewModel()
            {
                HotelId = hotelId,
                Hotel = _mapper.Map<SelectedHotelUIDto>(hotel),
                HotelRooms = _mapper.Map<IEnumerable<HotelRoomUIDto>>(hotelRooms),
                Images = _mapper.Map<IEnumerable<ImageUIDto>>(images)
            };

            ViewBag.Hotel = hotelModel;

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors = errors });
        }
    }
}
