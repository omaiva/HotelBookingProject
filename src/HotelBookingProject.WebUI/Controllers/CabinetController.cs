using AutoMapper;
using HotelBookingProject.Application.Filters;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Domain.Enums;
using HotelBookingProject.WebUI.DTO;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelBookingProject.WebUI.Controllers
{
    [Authorize(Roles = "User")]
    public class CabinetController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICabinetService _cabinetService;
        private readonly IMapper _mapper;

        public CabinetController(ICabinetService cabinetService, IMapper mapper, UserManager<User> userManager)
        {
            _cabinetService = cabinetService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> PersonalCabinet()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Bookings(int currentPage = 1, string? currentFilter = null, BookingStatusType? selectedStatus = null)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Json(new { success = false, message = "User ID is not valid." });
            }

            var filter = new BookingFilter
            {
                PageNumber = currentPage,
                PageSize = 10, 
                CurrentFilter = currentFilter,
                SelectedStatus = selectedStatus
            };

            var bookings = await _cabinetService.GetBookings(userId, filter);

            
            var totalBookings = await _cabinetService.GetTotalBookingsCount(userId, filter); 
            var totalPages = (int)Math.Ceiling((double)totalBookings / filter.PageSize);

            var model = new BookingsViewModel
            {
                Bookings = _mapper.Map<IEnumerable<BookingUIDto>>(bookings),
                CurrentPage = filter.PageNumber,
                TotalPages = totalPages,
                CurrentFilter = filter.CurrentFilter,
                SelectedStatus = filter.SelectedStatus
            };

            return PartialView("Bookings", model);
        }

        [HttpPost]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            try
            {
                await _cabinetService.CancelBooking(bookingId);
                return Json(new { success = true});
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                ModelState.AddModelError(string.Empty, "User id is not valid.");
            }

            var dataModel = await _cabinetService.GetSettingsModel(userId);

            var model = _mapper.Map<SettingsViewModel>(dataModel);

            return PartialView("Settings", model);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(SettingsViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("Settings", model);

            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                ModelState.AddModelError(string.Empty, "User id is not valid.");
            }

            await _cabinetService.ChangeFirstName(userId, model.FirstName);
            await _cabinetService.ChangeLastName(userId, model.LastName);

            return View("PersonalCabinet");
        }
    }
}
