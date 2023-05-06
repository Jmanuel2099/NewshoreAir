using NewshoreAirAPI.Models.Response.JourneyResponse.Entities;
using NewshoreAirDomain.Journey.Entities;

namespace NewshoreAirAPI.Mapper
{
    public class TransportMapper : GeneralMapper<Transport, TransportResponse>
    {
        public override TransportResponse MapperT1T2(Transport input)
        {
            return new TransportResponse
            {
                FlightCarrier = input.FlightCarrier,
                FlightNumber = input.FlightNumber,
            };
        }

        public override IEnumerable<TransportResponse> MapperT1T2(IEnumerable<Transport> input)
        {
            foreach (var transport in input)
            {
                yield return MapperT1T2(transport);
            }
        }
    }
}
