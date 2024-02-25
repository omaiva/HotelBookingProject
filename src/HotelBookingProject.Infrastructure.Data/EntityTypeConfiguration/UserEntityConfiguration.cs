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
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable(t => t.HasCheckConstraint("CK_User_Password_Requirements", @"
            LEN(Password) >= 8 AND 
            Password LIKE '%[a-zA-Z]%' AND 
            Password LIKE '%[A-Z]%' AND 
            Password LIKE '%[0-9]%'"));

            builder.ToTable(t => t.HasCheckConstraint("CK_User_Email_Format", @"
            Email LIKE '%@%.%'"));
        }
    }
}
