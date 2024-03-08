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
    internal class HotelRoomEntityConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Hotel)
                .WithMany(p => p.HotelRooms)
                .HasForeignKey(p => p.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Image)
                .WithMany(p => p.HotelRooms)
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.HasBath)
                .HasDefaultValue(false);

            builder.Property(p => p.HasWiFi)
                .HasDefaultValue(false);

            builder.Property(p => p.HasContidioning)
                .HasDefaultValue(false);

            builder.Property(p => p.IsAvailable)
                .HasDefaultValue(false);

            builder.Property(p => p.Price)
                .HasColumnType("decimal")
                .HasPrecision(18,2);

            builder.HasData(
                new HotelRoom() { Id=1, Name= "Standard double room with 1 bed",
                    Description= "Spacious room with elegant interiors, satellite TV and a private bathroom with bathrobes, slippers and free toiletries.",
                    NumberOfBeds=2, HasBath=true, HasContidioning=true,HasWiFi=true,IsAvailable=true,Price = 100,HotelId=1,ImageId=2 }
                );
        }
    }
}
