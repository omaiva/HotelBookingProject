using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HotelBookingProject.WebUI.Controllers;
using BookingProject.WebUI.Controllers;
using AutoMapper;
using HotelBookingProject.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using HotelBookingProject.WebUI.Models;
using HotelBookingProject.Application.Models;
using Microsoft.AspNetCore.Mvc;
using HotelBookingProject.Application.DTO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HotelBookingProject.Tests.UnitTests
{
    public class WebUITests
    {
        private readonly Mock<ILogger<HomeController>> mockHomeLogger = new();
        private readonly Mock<IHotelService> mockHotelService = new();
        private readonly Mock<IBookingService> mockBookingService = new();
        private readonly Mock<IMapper> mockMapper = new();

        [Fact]
        public async Task Index_ReturnsViewResult_WithIndexViewModel()
        {
            //arrange
            var testData = new IndexModel();
            var testViewModel = new IndexViewModel();

            mockHotelService.Setup(s => s.GetDataForIndex(1)).ReturnsAsync(testData);
            mockMapper.Setup(m => m.Map<IndexViewModel>(It.IsAny<IndexModel>())).Returns(testViewModel);

            var controller = new HomeController(mockHomeLogger.Object, mockHotelService.Object, mockMapper.Object);

            //act
            var result = await controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);
            Assert.Equal(testViewModel, model);
        }

        [Fact]
        public async Task GetHotelsByCityId_ReturnsPartialViewResult_WithHotelListViewModel()
        {
            var testData = new HotelListModel(); 
            var testViewModel = new HotelListViewModel();
            int testCityId = 1;

            mockHotelService.Setup(s => s.GetDataForHotelList(testCityId)).ReturnsAsync(testData);
            mockMapper.Setup(m => m.Map<HotelListViewModel>(It.IsAny<HotelListModel>())).Returns(testViewModel);

            var controller = new HomeController(mockHomeLogger.Object, mockHotelService.Object, mockMapper.Object);

            var result = await controller.GetHotelsByCityId(testCityId);

            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("HotelList", partialViewResult.ViewName);
            var model = Assert.IsAssignableFrom<HotelListViewModel>(partialViewResult.ViewData.Model);
            Assert.Equal(testViewModel, model); 
        }

        [Fact]
        public async Task SelectedHotel_ReturnsViewResult_WithSelectedHotelViewModel()
        {
            int testHotelId = 1;
            var testDataModel = new SelectedHotelModel();
            var testViewModel = new SelectedHotelViewModel();

            mockHotelService.Setup(service => service.GetDataForSelectedHotel(testHotelId))
            .ReturnsAsync(testDataModel);

            mockMapper.Setup(mapper => mapper.Map<SelectedHotelViewModel>(It.IsAny<SelectedHotelModel>()))
                .Returns(testViewModel);

            var controller = new HotelController(mockHotelService.Object, mockBookingService.Object, mockMapper.Object);

            var result = await controller.SelectedHotel(testHotelId);

            Assert.IsType<ViewResult>(result);
            Assert.Equal(testViewModel, controller.ViewBag.Hotel);
        }

        [Fact]
        public async Task SelectedHotelPost_ReturnsFailureJson_WithInvalidUserId()
        {
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new Mock<ClaimsPrincipal>();
            var testModel = new BookingModel();

            mockUser.Setup(u => u.FindFirst(It.IsAny<string>())).Returns(value: null);
            mockHttpContext.SetupGet(c => c.User).Returns(mockUser.Object);

            var controller = new HotelController(mockHotelService.Object, mockBookingService.Object, mockMapper.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            var result = await controller.SelectedHotel(testModel);

            var jsonResult = Assert.IsType<JsonResult>(result);
            var value = jsonResult.Value;

            var successProperty = value.GetType().GetProperty("success");
            var errorsProperty = value.GetType().GetProperty("errors");
            Assert.NotNull(successProperty);
            Assert.NotNull(errorsProperty);
            var successValue = (bool)successProperty.GetValue(value);
            var errorsValue = (string)errorsProperty.GetValue(value);
            Assert.False(successValue);
            Assert.Equal("User ID is not valid.", errorsValue);
        }

        [Fact]
        public async Task SelectedHotelPost_ReturnsErrorJson_WithInvalidModelState()
        {
            var testModel = new BookingModel();

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "mockUser@example.com"),
            };
            var mockIdentity = new ClaimsIdentity(userClaims, "TestAuthType");
            var mockUserPrincipal = new ClaimsPrincipal(mockIdentity);

            var controller = new HotelController(mockHotelService.Object, mockBookingService.Object, mockMapper.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = mockUserPrincipal }
                }
            };
            controller.ModelState.AddModelError("TestError", "Test error message");

            var result = await controller.SelectedHotel(testModel);

            var jsonResult = Assert.IsType<JsonResult>(result);
            var value = jsonResult.Value;

            var successProperty = value.GetType().GetProperty("success");
            var errorsProperty = value.GetType().GetProperty("errors");
            Assert.NotNull(successProperty);
            Assert.NotNull(errorsProperty);
            var successValue = (bool)successProperty.GetValue(value);
            var errorsValue = (List<string>)errorsProperty.GetValue(value);
            Assert.False(successValue);
            Assert.Contains("Test error message", errorsValue);
        }
    }
}
