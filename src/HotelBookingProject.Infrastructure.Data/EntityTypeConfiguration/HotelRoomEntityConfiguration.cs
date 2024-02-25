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
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.HasBath)
                .HasDefaultValue(false);

            builder.Property(p => p.HasWiFi)
                .HasDefaultValue(false);

            builder.Property(p => p.HasContidioning)
                .HasDefaultValue(false);

            builder.Property(p => p.IsAvailable)
                .HasDefaultValue(false);

            builder.Property(p => p.Price)
                .HasColumnType("decimal");
        }
    }
}
