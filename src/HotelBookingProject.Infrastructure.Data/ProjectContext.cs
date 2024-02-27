using HotelBookingProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HotelBookingProject.Infrastructure.Data
{
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
