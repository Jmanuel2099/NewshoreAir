using NewshoreAirDomain.Journey.Entities;
using NewshoreAirInfrastructure.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Mapper
{
    public class TransportMapper : GeneralMapper<TransportModel, Transport>
    {
        public override Transport MapperT1T2(TransportModel input)
        {
            return new Transport 
            {
                TransportId = input.TransportId,
                FlightCarrier = input.FlightCarrier,
                FlightNumber = input.FlightNumber,
            };
        }

        public override IEnumerable<Transport> MapperT1T2(IEnumerable<TransportModel> input)
        {
            foreach (var transport in input)
            {
                yield return MapperT1T2(transport);
            }
        }

        public override TransportModel MapperT2T1(Transport input)
        {
            return new TransportModel
            {
                FlightCarrier = input.FlightCarrier,
                FlightNumber = input.FlightNumber,
            };
        }

        public override IEnumerable<TransportModel> MapperT2T1(IEnumerable<Transport> input)
        {
            foreach (var transport in input)
            {
                yield return MapperT2T1(transport);
            }
        }
    }
}
