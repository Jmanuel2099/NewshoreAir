using NewshoreAirDomain.Journey.Entities;
using NewshoreAirInfrastructure.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Mapper
{
    public class FlightMapper : GeneralMapper<FlightModel, Flight>
    {
        public override Flight MapperT1T2(FlightModel input)
        {
            TransportMapper transportMapper = new TransportMapper();

            return new Flight
            {
                FlightId = input.FlightId,
                Origin = input.Origin,
                Destination = input.Destination,
                Price = input.Price,
                Transport = transportMapper.MapperT1T2(input.Transport)
            };
        }

        public override IEnumerable<Flight> MapperT1T2(IEnumerable<FlightModel> input)
        {
            foreach (var flight in input)
            {
                yield return MapperT1T2(flight);
            }
        }

        public override FlightModel MapperT2T1(Flight input)
        {
            TransportMapper transportMapper = new TransportMapper();

            return new FlightModel
            {
                Origin = input.Origin,
                Destination = input.Destination,
                Price = input.Price,
                TransportId = input.Transport.TransportId  
            };

        }

        public override IEnumerable<FlightModel> MapperT2T1(IEnumerable<Flight> input)
        {
            foreach (var flight in input)
            {
                yield return MapperT2T1(flight);
            }
        }
    }
}
