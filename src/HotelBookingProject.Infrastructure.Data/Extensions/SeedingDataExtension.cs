using HotelBookingProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Infrastructure.Data.Extensions
{
    public static class SeedingDataExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingStatus>().HasData(
                new BookingStatus() { Id = 1, Description = "Active" },
                new BookingStatus() { Id = 2, Description = "Closed" },
                new BookingStatus() { Id = 3, Description = "Canceled" }
            );

            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Kyiv" },
                new City() { Id = 2, Name = "Lviv" },
                new City() { Id = 3, Name = "Odessa" },
                new City() { Id = 4, Name = "Kharkiv" },
                new City() { Id = 5, Name = "Dnipro" },
                new City() { Id = 6, Name = "Zaporizhzhia" }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    Name = "Opera Hotel",
                    Description = "\"Opera\" is one of the top best hotels in Kiev not only by location, but also by all the main criteria for choosing premium-class accommodation. In addition to the luxurious architecture of the building itself, there are 140 elegant and stylized for opera performances rooms for every taste - one-room, with a living area, suites in Japanese, French and Moroccan style.",
                    NumberOfFloors = 4,
                    Street = "Khmelnitskogo",
                    HouseNumber = 53,
                    Latitude = 50.44822300456948m,
                    Longitude = 30.49996667023849m,
                    CityId = 1,
                    ImageId = 1
                }
            );

            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom()
                {
                    Id = 1,
                    Name = "Standard double room with 1 bed",
                    Description = "Spacious room with elegant interiors, satellite TV and a private bathroom with bathrobes, slippers and free toiletries.",
                    NumberOfBeds = 2,
                    HasBath = true,
                    HasContidioning = true,
                    HasWiFi = true,
                    IsAvailable = true,
                    Price = 100,
                    HotelId = 1,
                    ImageId = 2
                }
            );

            modelBuilder.Entity<Image>().HasData(
                new Image() { Id = 1, Path = @"/images/Hotels/opera_hotel.jpg" },
                new Image() { Id = 2, Path = @"/images/Rooms/room1.jpg" }
            );
        }
    }
}
