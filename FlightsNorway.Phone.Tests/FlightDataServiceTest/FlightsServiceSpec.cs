﻿using System.Collections.Generic;

using FlightsNorway.Model;
using FlightsNorway.FlightDataServices;
using Microsoft.Phone.Reactive;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightsNorway.Tests.FlightDataServiceTest
{
    [TestClass]
    public class FlightsServiceSpec : SilverlightTest
    {
        [TestMethod, Asynchronous, Timeout(10000), Tag(Tags.WebService)]
        public void Can_get_flights_from_Oslo_airport()
        {
            var flightsList = new List<Flight>();
            
            EnqueueCallback(() => _service.GetFlightsFrom(new Airport("OSL", "Oslo")).Subscribe(flightsList.AddRange));
            EnqueueConditional(() => flightsList.Count > 0);
            EnqueueCallback(() => AssertFlightsAreLoaded(flightsList));
            EnqueueCallback(() => Assert.IsTrue(_service.Airports.Count > 0));
            EnqueueCallback(() => Assert.IsTrue(_service.Airlines.Count > 0));
            EnqueueCallback(() => Assert.IsTrue(_service.Statuses.Count > 0));

            EnqueueTestComplete();
        }

        private static void AssertFlightsAreLoaded(List<Flight> flights)
        {
            Assert.IsTrue(flights.Count > 0);

            foreach(var flight in flights)
            {
                Assert.IsNotNull(flight.Airline);
                Assert.IsNotNull(flight.Airport);
                Assert.IsNotNull(flight.FlightStatus);
            }
        }

        [TestInitialize]
        public void Setup()
        {
            _service = new FlightsService();
        }

        private FlightsService _service;
    }
}