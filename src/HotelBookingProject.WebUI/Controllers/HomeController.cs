using BookingProject.WebUI.Models;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectContext _context;

        public HomeController(ILogger<HomeController> logger, ProjectContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _context.Cities.ToListAsync();
            var defaultHotels = await _context.Hotels.Where(h => h.CityId == 1).ToListAsync();

            return View((Cities: cities, Hotels: defaultHotels));
        }

        public async Task<IActionResult> GetHotelsByCityId(int cityId)
        {
            var hotels = await _context.Hotels
                                .Where(h => h.CityId == cityId)
                                .ToListAsync();
            return PartialView("HotelList", hotels);
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
