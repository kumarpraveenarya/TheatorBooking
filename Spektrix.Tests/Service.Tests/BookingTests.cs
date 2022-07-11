using Spektrix.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Spektrix.Enums;
using Spektrix.Exception;
using Spektrix.Models;
using Booking = Spektrix.Services.Booking;

namespace Spektrix.Tests.Service.Tests
{
    [TestFixture]
    public class BookingTests
    {
        private Mock<IPerformance> _performanceService;
        private IBooking _bookingService; 

        [SetUp]
        public void Init()
        {
            _performanceService = new Mock<IPerformance>();
            _bookingService = new Booking(_performanceService.Object);
        }

        [Test]
        public void When_seats_available_book_Seats()
        {
            _performanceService.Setup(x => x.GetEmptySeats()).Returns(() => GetSeats().ToList());

            var result = _bookingService.BookSeat(3);

            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void When_seats_not_available_throw_Exception()
        {
            _performanceService.Setup(x => x.GetEmptySeats()).Returns(() => GetSeats().ToList());

            Assert.Throws<SeatsNotFoundException>(() => _bookingService.BookSeat(5));
        }

        [Test]
        public void When_seats_available_book_Seats_from_first_available_left_right_front_back()
        {
            _performanceService.Setup(x => x.GetEmptySeats()).Returns(() => GetSeats().ToList());

            var result = _bookingService.BookSeat(3);

            Assert.AreEqual(result.FirstOrDefault()?.SeatRow, 'B');
            Assert.AreEqual(result.FirstOrDefault()?.SeatNum, 2);
        }

        public IEnumerable<Seat> GetSeats()
        {
            return new List<Seat>()
            {
                new Seat() { SeatNum = 1, SeatRow = 'A', State = SeatState.Reserved },
                new Seat() { SeatNum = 2, SeatRow = 'A', State = SeatState.Reserved },
                new Seat() { SeatNum = 1, SeatRow = 'B', State = SeatState.Reserved },
                new Seat() { SeatNum = 2, SeatRow = 'B', State = SeatState.Empty },
                new Seat() { SeatNum = 1, SeatRow = 'C', State = SeatState.Empty },
                new Seat() { SeatNum = 2, SeatRow = 'C', State = SeatState.Empty }
            }.Where(x => x.State == SeatState.Empty);
        }
    }

    
}
