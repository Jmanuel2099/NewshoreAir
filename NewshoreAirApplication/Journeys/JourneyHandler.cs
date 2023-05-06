﻿using NewshoreAirApplication.Interfaces.Persistance;
using NewshoreAirApplication.Interfaces.Services;
using NewshoreAirDomain.Errors;
using NewshoreAirDomain.Journey;
using NewshoreAirDomain.Journey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Journeys
{
    public class JourneyHandler : IJourneyHandler
    {
		private IJourneyRespository _journeyRespository;
		private INewshoreFlights _newsFlights;

		public JourneyHandler(IJourneyRespository journeyRespository, INewshoreFlights newsFlights)
        {
            _journeyRespository = journeyRespository;
            _newsFlights = newsFlights;
        }

        public async Task<Journey> GetJourney(string origin, string destination)
        {
			try
			{
                var journeys = _journeyRespository.GetJourneys(origin, destination);
                if (journeys.Any())
                {
                    return journeys.First();
                }

                IEnumerable<Flight> flights = await _newsFlights.GetNewshoreFlights();
                if (!flights.Any())
                {
                    throw new CustomError("There are no logs on the newshore air server.", null);
                }

                IEnumerable<Flight> journeyRoute = calculateJourneyRoute(
                    flights, 
                    origin, 
                    destination);

                Journey newJourney = new Journey() 
                {
                    Origin = origin,
                    Destination = destination,
                    Price = calculateJourneyPrice(journeyRoute),
                    Flights = journeyRoute
                };
                _journeyRespository.CreateJourney(newJourney);

                return newJourney;
            }
			catch (Exception ex)
			{
				throw new CustomError(
                    "Something happened while the journey was being obtained.",
                    ex);
			}
        }

        private IEnumerable<Flight> calculateJourneyRoute(
            IEnumerable<Flight> flights, 
            string origin, 
            string destination)  
        {
            List<Flight> result = new List<Flight>();
            string currentOrigin = origin;
            while (currentOrigin != destination)
            {
                var nextFlight = flights.FirstOrDefault(f => f.Origin == currentOrigin);
                if (nextFlight == null)
                {
                    break;
                }
                result.Add(nextFlight);
                currentOrigin = nextFlight.Destination;
            }

            return result;
        }

        private float calculateJourneyPrice(IEnumerable<Flight> flights) 
        {
            float price = 0f;
            foreach (Flight flight in flights) 
            {
                price += flight.Price;
            }

            return price;
        }

    }
}
