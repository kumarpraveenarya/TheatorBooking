using System.Collections.Generic;
using Spektrix.Enums;

namespace Spektrix.Models
{
    public class Booking
    {
        public BookingState BookingState { get; set; }

        public List<Seat> BookedSeats { get; set; }
    }
}
