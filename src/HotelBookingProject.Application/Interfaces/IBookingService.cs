using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Interfaces
{
    public interface IBookingService
    {
        Task AddBooking(int userId, int roomId, DateTime startDate, DateTime endDate);
        Task UpdateBookingStatuses();
    }
}
