using Airport.Client;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Airport.XUnitTest
{
    public class AirportTest
    {
        [Fact]
        public void DataNotEmpty()
        {
            ReadSchedule readSchedule = new ReadSchedule();
            Assert.NotEmpty(readSchedule.getAll());
        }
        [Fact]
        public void DataNotNull()
        {
            ReadSchedule readSchedule = new ReadSchedule();
            Assert.NotNull(readSchedule.getAll());
        }
        [Fact]
        public void DataIsType()
        {
            ReadSchedule readSchedule = new ReadSchedule();
            Assert.IsType<List<SchedulePlan>>(readSchedule.getAll());
        }
        [Theory]
        [InlineData(300)]
        [InlineData(500)]
        public void GetFlightExpensiveThan(decimal price)
        {
            ReadSchedule readSchedule = new ReadSchedule();
            var allSchedules = readSchedule.getAll();
            Assert.True(allSchedules.Max(x => x.Price) > price);
        }
    }
}