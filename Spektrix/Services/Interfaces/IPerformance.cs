using System;
using System.Collections.Generic;
using Spektrix.Enums;
using Spektrix.Models;

namespace Spektrix.Services.Interfaces
{
    public interface IPerformance
    {
        public List<Seat> GetAllSeats();

        public List<Seat> GetEmptySeats();

        public List<Seat> GetReservedSeats();
    }
}
