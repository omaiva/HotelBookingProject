using HotelBookingProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Infrastructure.Data.EntityTypeConfiguration
{
    internal class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(p => p.Id);


            builder.HasOne(p => p.City)
                .WithMany(p => p.Hotels)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Image)
                .WithMany(p => p.Hotels)
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Latitude)
                .HasColumnType("decimal")
                .HasPrecision(18,14);

            builder.Property(p => p.Longitude)
                .HasColumnType("decimal")
                .HasPrecision(18, 14);

            builder.HasData(
                new Hotel() { 
                    Id=1,
                    Name= "Opera Hotel",
                    Description= "\"Opera\" is one of the top best hotels in Kiev not only by location, but also by all the main criteria for choosing premium-class accommodation. In addition to the luxurious architecture of the building itself, there are 140 elegant and stylized for opera performances rooms for every taste - one-room, with a living area, suites in Japanese, French and Moroccan style.",
                    NumberOfFloors=4,
                    Street= "Khmelnitskogo",
                    HouseNumber=53,
                    Latitude= 50.44822300456948m,
                    Longitude= 30.49996667023849m,
                    CityId=1,
                    ImageId=1
                }
                );
        }
    }
}
