using AutoMapper;
using BookingProject.WebUI.Models;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.WebUI.DTO;
using HotelBookingProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookingProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IHotelService hotelService, IMapper mapper)
        {
            _logger = logger;
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dataModel = await _hotelService.GetDataForIndex(1);

            var model = _mapper.Map<IndexViewModel>(dataModel);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelsByCityId(int cityId)
        {
            var dataModel = await _hotelService.GetDataForHotelList(cityId);

            var model = _mapper.Map<HotelListViewModel>(dataModel);

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
