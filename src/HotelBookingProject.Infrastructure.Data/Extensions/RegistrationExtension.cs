using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Infrastructure.Data.Extensions
{
    public static class RegistrationExtension
    {
        public static void AddStorage(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
