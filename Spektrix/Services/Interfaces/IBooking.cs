using System.Collections.Generic;
using Spektrix.Models;

namespace Spektrix.Services.Interfaces
{
    public interface IBooking
    {
        public List<Seat> BookSeat(int noofseats);
    }
}