﻿using System.Collections.Generic;
using FlightsNorway.Model;
using FlightsNorway.FlightDataServices;
using Microsoft.Phone.Reactive;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightsNorway.Tests.FlightDataServiceTest
{
    [TestClass]
    public class AirlineNamesServiceSpec : SilverlightTest
    {
        [TestMethod, Asynchronous, Timeout(5000), Tag(Tags.WebService)]
        public void Should_be_able_to_get_airline_names()
        {
            var airlineList = new List<Airline>();
            _service.GetAirlines().Subscribe(airlineList.AddRange);
            EnqueueConditional(() => airlineList.Count > 0);
            EnqueueTestComplete();
        }

        [TestInitialize]
        public void Setup()
        {
            _service = new AirlineNamesService();            
        }

        private AirlineNamesService _service;
    }
}
