using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAirportPanelV2
{
    public class Airport
    {
        //private FlightStatus status;

        public enum FlightStatus
        {
            CheckIn = 1,
            GateClosed,
            Arrived,
            DepartedAt,
            Unknown,
            Canceled,
            ExpectedAt,
            Delayed,
            InFlight,

        }
        //public Airport()
        //{

        //}
        public Airport(DateTime dateArrival, DateTime dateDeparture, string flightNumber, string cityOfArrivval, string cityOfDeparture,
            string airline, string terminal, string portofArrival, string portofDeparture, int flightStatus)
        {
            DateArrival = dateArrival;
            DateDeparture = dateDeparture;
            FlightNumber = flightNumber;
            CityOfArrival = cityOfArrivval;
            CityOfDeparture = cityOfDeparture;
            PortOfArrival = portofArrival;
            PortOfDeparture = portofDeparture;
            Terminal = terminal;
            Airline = airline;
            Status = (FlightStatus)flightStatus;
        }

        public Airport()
        {
        }

        public DateTime DateArrival { get; set; }

        public DateTime DateDeparture { get; set; }

        public string FlightNumber { get; set; }
        public string CityOfArrival { get; set; }
        public string CityOfDeparture { get; set; }
        public string PortOfArrival { get; set; }
        public string PortOfDeparture { get; set; }
        public string Airline { get; set; }
        public string Terminal { get; set; }
        public FlightStatus Status { get; set; }

        


    }
}
