using NewshoreAirDomain.Journey;
using NewshoreAirInfrastructure.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Mapper
{
    public class JourneyMapper : GeneralMapper<JourneyModel, Journey>
    {
        public override Journey MapperT1T2(JourneyModel input)
        {
            var flights = input.Flights.Select(flight => flight.Flight);
            FlightMapper flightMapper = new FlightMapper();
            return new Journey 
            {
                JourneyId = input.JourneyId,
                Origin = input.Origin,
                Destination = input.Destination,
                Price = input.Price,
                Flights = flightMapper.MapperT1T2(flights)
            };
        }

        public override IEnumerable<Journey> MapperT1T2(IEnumerable<JourneyModel> input)
        {
            foreach (var journey in input)
            {
                yield return MapperT1T2(journey);
            }
        }

        public override JourneyModel MapperT2T1(Journey input)
        {
            return new JourneyModel 
            {
                Origin = input.Origin,
                Destination = input.Destination,
                Price = input.Price,
            };
        }

        public override IEnumerable<JourneyModel> MapperT2T1(IEnumerable<Journey> input)
        {
            foreach (var journey in input)
            {
                yield return MapperT2T1(journey);
            }
        }
    }
}
