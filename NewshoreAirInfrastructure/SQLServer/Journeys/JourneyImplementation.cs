using Microsoft.EntityFrameworkCore;
using NewshoreAirApplication.Interfaces.Persistance;
using NewshoreAirDomain.Errors;
using NewshoreAirDomain.Journey;
using NewshoreAirDomain.Journey.Entities;
using NewshoreAirInfrastructure.SQLServer.Flights;
using NewshoreAirInfrastructure.SQLServer.Mapper;
using NewshoreAirInfrastructure.SQLServer.Models;
using NewshoreAirInfrastructure.SQLServer.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Journeys
{
    public class JourneyImplementation : IJourneyRespository
    {
        public Journey GetJourneys(string origin, string destination)
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try 
                {
                    var record = db.Journeys
                        .Include(j => j.Flights)
                        .ThenInclude(jf => jf.Flight)
                        .FirstOrDefault();
                    if (record == null)
                    {
                        return null;
                    }
                    TransportImplementation transportImplementation = new TransportImplementation();
                    TransportMapper transportMapper  = new TransportMapper();
                    foreach (var flight in record.Flights)
                    {
                        var trasport = transportMapper
                            .MapperT2T1(transportImplementation.getTransportById(flight.FlightId));
                        flight.Flight.Transport = trasport;
                    }
                    JourneyMapper journeyMapper = new JourneyMapper();
                    var r = journeyMapper.MapperT1T2(record);
                    return r;
                } 
                catch (Exception ex) 
                {
                    throw new CustomError(
                        "Something happened while trying to search for the journey in the database.",
                        ex);
                }
                
            }
        }

        public void CreateJourney(Journey journey)
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try
                {
                    JourneyMapper mapper = new JourneyMapper();
                    JourneyModel record = mapper.MapperT2T1(journey);
                    db.Journeys.Add(record);
                    db.SaveChanges();
                    
                    int lastJourneyId = db.Journeys.OrderByDescending(x => x.JourneyId)
                        .FirstOrDefault()
                        .JourneyId;
                    foreach (var flight in journey.Flights)
                    {
                        createFlight(flight);
                        int lastFlightId = db.Flights.OrderByDescending(x => x.FlightId)
                        .FirstOrDefault()
                        .FlightId;
                        AssingFlightToJourney(lastFlightId, lastJourneyId);
                    }
                }
                catch (Exception ex)
                {
                    throw new CustomError(
                        "Something happened while trying to create a journey in the database.",
                        ex);
                }
            }
        }

        private void createFlight(Flight flight) 
        {
            FlightImplementation flightImplementation = new FlightImplementation();
            flightImplementation.CreateFlight(flight);
        }

        private void AssingFlightToJourney(int flightId, int journeyId) 
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try
                {
                    db.JourneyFlights.Add(new JourneyFlightModel()
                    {
                        FlightId = flightId,
                        JourneyId = journeyId
                    });
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new CustomError(
                        "Something happened while trying to assign a flight to the journey.",
                        ex);
                }
            }
        }

        
    }
}
