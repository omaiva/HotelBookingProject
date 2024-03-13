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
            var dataModel = await _hotelService.GetDataForSelectedHotel(hotelId);

            var model = _mapper.Map<SelectedHotelViewModel>(dataModel);

            ViewBag.Hotel = model;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SelectedHotel(BookingModel model)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Json(new { success = false, errors = "User ID is not valid." });
            }

            if (ModelState.IsValid)
            {
                await _bookingService.AddBooking(userId, model.HotelRoomId, model.StartDate, model.EndDate);
                return Json(new { success = true });
            }

            var hotelId = model.HotelId;

            var dataModel = await _hotelService.GetDataForSelectedHotel(hotelId);

            var newModel = _mapper.Map<SelectedHotelViewModel>(dataModel);

            ViewBag.Hotel = newModel;

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors = errors });
        }
    }
}
