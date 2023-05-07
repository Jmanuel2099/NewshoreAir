using NewshoreAirDomain.Errors;
using NewshoreAirDomain.Journey;
using NewshoreAirDomain.Journey.Entities;
using NewshoreAirInfrastructure.SQLServer.Mapper;
using NewshoreAirInfrastructure.SQLServer.Models;
using NewshoreAirInfrastructure.SQLServer.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Flights
{
    public class FlightImplementation
    {

        public Flight GetFlightById(int flightId) 
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try
                {
                    var record = db.Flights.Where(f => f.FlightId == flightId).FirstOrDefault();
                    if (record != null) 
                    {
                        throw new CustomError("Dont exist Flight in the database.", null);
                    }
                    FlightMapper mapper = new FlightMapper();

                    return mapper.MapperT1T2(record);
                }
                catch (Exception ex)
                {
                    throw new CustomError(
                        "Something happened while trying to get a Flight in the database.",
                        ex);
                }
            }
        }

        public void CreateFlight(Flight flight)
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try
                {
                    createTransport(flight.Transport);

                    FlightMapper mapper = new FlightMapper();
                    FlightModel record = mapper.MapperT2T1(flight);
                    record.TransportId = db.Transports.
                        OrderByDescending(x => x.TransportId)
                        .FirstOrDefault()
                        .TransportId;   
                    db.Add(record);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new CustomError(
                        "Something happened while trying to create a Transport in the database.",
                        ex);
                }
            }
        }

        private void createTransport(Transport transport)
        {
            TransportImplementation transportImplementation = new TransportImplementation();
            transportImplementation.CreateTransport(transport);
        }
    }
}
