using System.Linq;
using NUnit.Framework;
using Moq;
using Spektrix.Services;
using Spektrix.Services.Interfaces;

namespace Spektrix.Tests.Service.Tests
{
    [TestFixture]
    public class PerformanceTests
    {
        private IPerformance _performanceService;

        [SetUp]
        public void Init()
        {
            _performanceService = new Performance();
        }

        [Test]
        public void Performance_should_have_15_Seats()
        {
            Assert.AreEqual(_performanceService.GetAllSeats().Count, 15);
        }

        [Test]
        public void Performance_should_have_3_Rowa()
        {
            Assert.AreEqual(_performanceService.GetAllSeats().GroupBy(x => x.SeatRow).Count(), 3);
        }

        [Test]
        public void Performance_should_have_15_EmptySeats()
        {
            Assert.AreEqual(_performanceService.GetEmptySeats().Count(), 15);
        }

        [Test]
        public void Performance_should_have_0_ResearvedSeats()
        {
            Assert.AreEqual(_performanceService.GetReservedSeats().Count(), 0);
        }
    }
}
