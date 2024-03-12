using HotelBookingProject.Application.DTO;
using HotelBookingProject.Application.Models;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Interfaces
{
    public interface IHotelService
    {
        Task<IndexModel> GetDataForIndex(int id);
        Task<HotelListModel> GetDataForHotelList(int id);
        Task<SelectedHotelModel> GetDataForSelectedHotel(int id);
    }
}
