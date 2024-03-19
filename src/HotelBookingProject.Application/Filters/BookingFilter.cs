using HotelBookingProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Filters
{
    public class BookingFilter : BookingPagination
    {
        public string? CurrentFilter { get; set; }
        public BookingStatusType? SelectedStatus { get; set; }

    }
}
