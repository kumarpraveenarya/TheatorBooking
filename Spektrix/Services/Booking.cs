using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spektrix.Enums;
using Spektrix.Exception;
using Spektrix.Models;
using Spektrix.Services.Interfaces;

namespace Spektrix.Services
{
    public class Booking : IBooking
    {
        private IPerformance _performance;
        public Booking(IPerformance performance)
        {
            this._performance = performance;
        }

        public List<Seat> BookSeat(int noOfSeats)
        {
            var emptySeats = _performance.GetEmptySeats();

            if (emptySeats.Count < noOfSeats)
            {
                throw new SeatsNotFoundException(
                    $"No Enough seats left, required seats {noOfSeats} but found {emptySeats.Count}.");
            }

            var seatsToBook = emptySeats.Take(noOfSeats).ToList();
            seatsToBook.ForEach(x => x.State = SeatState.Reserved);
            return seatsToBook;
        }
    }
}
