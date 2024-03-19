using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingProject.Application.Filters
{
    public class BookingPagination
    {
        private const int MaxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int _pageSize;
        public int PageSize { get { return _pageSize; } set { _pageSize = value > MaxPageSize ? MaxPageSize : value; } }

    }
}
