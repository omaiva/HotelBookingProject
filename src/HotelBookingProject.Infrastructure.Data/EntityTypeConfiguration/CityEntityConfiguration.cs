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
    internal class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(30)");

            builder.HasData(
                new City() { Id = 1, Name = "Kyiv" },
                new City() { Id = 2, Name = "Lviv" },
                new City() { Id = 3, Name = "Odessa" },
                new City() { Id = 4, Name = "Kharkiv" },
                new City() { Id = 5, Name = "Dnipro" },
                new City() { Id = 6, Name = "Zaporizhzhia" }
                );
        }
    }
}
