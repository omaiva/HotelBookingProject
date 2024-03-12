using HotelBookingProject.Application.Services;
using HotelBookingProject.Application.Interfaces;
using HotelBookingProject.Domain.Entities;
using HotelBookingProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelBookingProject.WebUI.MappingProfile;
using HotelBookingProject.Application.BackgroundServices;
using HotelBookingProject.Infrastructure.Data.Extensions;

namespace BookingProject.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("LocalDbSqlServer") ?? throw new InvalidOperationException("Connection string 'LocalDbSqlServer' not found.");

            builder.Services.AddStorage(connectionString);
            
            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ProjectContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddTransient<IHotelService, HotelService>();
            builder.Services.AddTransient<IBookingService, BookingService>();
            builder.Services.AddHostedService<BookingStatusUpdaterService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.DataBaseEnsureCreated();
                app.RolesEnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
