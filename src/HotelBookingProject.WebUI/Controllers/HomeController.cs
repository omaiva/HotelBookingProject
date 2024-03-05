using BookingProject.WebUI.Models;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookingProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;

        public HomeController(ILogger<HomeController> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel()
            {
                Cities = await _hotelService.GetCities(),
                Hotels = await _hotelService.GetHotelsByFirstId(),
                Images = await _hotelService.GetImages()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelsByCityId(int cityId)
        {
            var model = new HotelListViewModel()
            {
                Hotels = await _hotelService.GetHotelsById(cityId),
                Images = await _hotelService.GetImages()
            };
            
            return PartialView("HotelList", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
