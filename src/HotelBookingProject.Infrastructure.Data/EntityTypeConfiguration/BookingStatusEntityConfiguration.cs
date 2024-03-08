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
    internal class BookingStatusEntityConfiguration : IEntityTypeConfiguration<BookingStatus>
    {
        public void Configure(EntityTypeBuilder<BookingStatus> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasData(
                new BookingStatus() { Id=1,Description="Active"},
                new BookingStatus() { Id = 2, Description = "Closed" },
                new BookingStatus() { Id = 3, Description = "Canceled" }
                );
        }
    }
}
