﻿using System;

namespace FlightsNorway.Lib.Model
{
    public class Flight
    {
        public string UniqueId { get; set; }
        public Airline Airline { get; set; }
        public Airport Airport { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public DateTime StatusTime { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string FlightId { get; set; }
        public FlightArea LastLeg { get; set; }
        public Direction Direction { get; set; }
        public string Gate { get; set; }
        public string Belt { get; set; }

        public Flight() : this(new Airline(), new Airport())
        {
        }

        public Flight(Airline airline, Airport airport)
        {
            Airline = airline;
            Airport = airport;
            FlightStatus = new FlightStatus();            
        }
		
		public string Line1()
		{
			if(Direction == Direction.Depature)
			{
                return string.Format("{0} to {1} at {2:HH:mm}", FlightId, Airport.Name, ScheduledTime);
			}
			
			return string.Format("{0} from {1} at {2:HH:mm}", FlightId, Airport.Name, ScheduledTime);
		}
		
		public string Line2()
		{
			if(Direction == Direction.Depature)
			{
				return string.Format("Gate {0} - Status: {1}", Gate, FlightStatus.Status.StatusTextEnglish);
			}
			
			return string.Format("Status: {0} - Belt: {1}", FlightStatus.Status.StatusTextEnglish, Belt);
		}

        public override string ToString()
        {
            if(Direction == Direction.Depature)
            {
                return string.Format("{0} {1:HH:mm} {2} {3} {4}", 
				                     FlightId, 
				                     ScheduledTime, 
				                     Gate, 
				                     Airport.Name, 
				                     FlightStatus.Status.StatusTextNorwegian);
            }

            return string.Format("{0} {1:HH:mm} {2} {3} {4} {5:HH:mm}",                     
                                 FlightId, 
			                     ScheduledTime, 
			                     Belt, 
			                     Airport.Name,
                                 FlightStatus.Status.StatusTextEnglish, 
			                     FlightStatus.StatusTime);
        }
    }
}
