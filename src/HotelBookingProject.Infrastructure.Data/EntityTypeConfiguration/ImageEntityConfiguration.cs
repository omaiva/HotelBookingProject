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
    internal class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasData(
                new Image() { Id=1,Path= @"/images/Hotels/opera_hotel.jpg" },
                new Image() { Id = 2, Path = @"/images/Rooms/room1.jpg" }
                );
        }
    }
}
