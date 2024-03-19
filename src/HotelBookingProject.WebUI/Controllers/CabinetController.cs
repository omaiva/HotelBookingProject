using AutoMapper;
using HotelBookingProject.Application.Filters;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Domain.Enums;
using HotelBookingProject.WebUI.DTO;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBookingProject.WebUI.Controllers
{
    [Authorize(Roles = "User")]
    public class CabinetController : Controller
    {
        private readonly ICabinetService _cabinetService;
        private readonly IMapper _mapper;

        public CabinetController(ICabinetService cabinetService, IMapper mapper)
        {
            _cabinetService = cabinetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> PersonalCabinet()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Bookings(int currentPage = 1, string currentFilter = null, BookingStatusType? selectedStatus = null)
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

            // Assuming your service now returns the total count within the Bookings collection, or you have a separate method to get the count.
            // You might need to adjust this if your service method signature or logic differs.
            var totalBookings = await _cabinetService.GetTotalBookingsCount(userId, filter); // This is a hypothetical method.
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
            return PartialView("Settings");
        }
    }
}
