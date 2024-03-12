using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Domain.Enums
{
    public enum BookingStatusType
    {
        [Description("Active")]
        Active = 1,
        [Description("Closed")]
        Closed = 2,
        [Description("Canceled")]
        Canceled = 3
    }
}
