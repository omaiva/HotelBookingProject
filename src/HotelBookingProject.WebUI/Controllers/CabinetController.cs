using AutoMapper;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.WebUI.DTO;
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
        public async Task<IActionResult> Bookings()
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Json(new { success = false, errors = "User ID is not valid." });
            }

            var dataModel = await _cabinetService.GetBookings(userId);

            var model = _mapper.Map<IEnumerable<BookingUIDto>>(dataModel);

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
