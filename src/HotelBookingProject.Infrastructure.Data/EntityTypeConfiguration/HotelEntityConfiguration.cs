﻿using HotelBookingProject.Domain.Entities;
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
        }
    }
}
