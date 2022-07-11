using Spektrix.Enums;

namespace Spektrix.Models
{
    public class Seat
    {
        public char SeatRow { get; set; }
        public int SeatNum { get; set; }
        public SeatState State { get; set; }
    }
}