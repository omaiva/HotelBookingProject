using HotelBookingProject.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Services
{
    public class BookingStatusUpdaterService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public BookingStatusUpdaterService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var projectContext = scope.ServiceProvider.GetRequiredService<ProjectContext>();
                    await UpdateBookingsStatuses(projectContext);
                }
                
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }

        private async Task UpdateBookingsStatuses(ProjectContext projectContext)
        {
            var today = DateTime.UtcNow.Date;
            var bookingsToUpdate = projectContext.Bookings
                                            .Where(b => b.EndDate < today && b.BookingStatusId == 1)
                                            .ToList();

            foreach (var booking in bookingsToUpdate)
            {
                projectContext.HotelRooms.First(r => r.Id == booking.HotelRoomId).IsAvailable = true;
                booking.BookingStatusId = 2;
            }

            await projectContext.SaveChangesAsync();
        }
    }
}
