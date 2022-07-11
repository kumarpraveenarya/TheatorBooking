using Spektrix.Enums;
using Spektrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Spektrix.Services.Interfaces;

namespace Spektrix.Services
{
    public class Performance :IPerformance
    {
        private int Capacity { get; set; } = 15;

        private int SeatsPerRaw { get; set; } = 5;
        private List<Seat> Seats { get; set; }

        public Performance()
        {
            int rows = Capacity / SeatsPerRaw;
            Seats = new List<Seat>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < SeatsPerRaw; j++)
                {
                    Seats.Add(new Seat {SeatRow = Convert.ToChar(i + 65), SeatNum = j+1,State = SeatState.Empty});
                }
            }
        }

        public List<Seat> GetAllSeats()
        {
            return Seats;
        }

        public List<Seat> GetReservedSeats()
        {
            return Seats.Where(x => x.State == SeatState.Reserved).ToList();
        }

        public List<Seat> GetEmptySeats()
        {
            return Seats.Where(x => x.State == SeatState.Empty).ToList();
        }
    }
}
