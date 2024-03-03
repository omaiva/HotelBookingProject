using BookingProject.WebUI.Models;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
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
            var model = new IndexViewModel()
            {
                Cities = await _context.Cities.ToListAsync(),
                Hotels = await _context.Hotels.Where(h => h.CityId == 1).ToListAsync(),
                Images = await _context.Images.ToListAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> GetHotelsByCityId(int cityId)
        {
            var model = new HotelListViewModel()
            {
                Hotels = await _context.Hotels
                                .Where(h => h.CityId == cityId)
                                .ToListAsync(),
                Images = await _context.Images.ToListAsync()
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
