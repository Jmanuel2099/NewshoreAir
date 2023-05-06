using NewshoreAirDomain.Journey.Entities;
using NewshoreAirInfrastructure.NewshoreAir.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.NewshoreAir.Mapper
{
    public class FlightMapper : GeneralMapper<FlightResponse, Flight>
    {
        public override Flight MapperT1T2(FlightResponse input)
        {
            return new Flight
            {
                Origin = input.DepartureStation,
                Destination = input.ArrivalStation,
                Price = input.Price,
                Transport = MapperTransport(input.FlightCarrier, input.FlightNumber)
            };
        }

        public override IEnumerable<Flight> MapperT1T2(IEnumerable<FlightResponse> input)
        {
            foreach (var flight in input)
            {
                yield return MapperT1T2(flight);
            }
        }

        private Transport MapperTransport(string flightCarrier, string flightNumber)
        {
            return new Transport
            {
                FlightCarrier = flightCarrier,
                FlightNumber = flightNumber
            };

        }
    }
}
