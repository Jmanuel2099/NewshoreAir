using NewshoreAirAPI.Models.Response.JourneyResponse.Entities;
using NewshoreAirDomain.Journey.Entities;

namespace NewshoreAirAPI.Mapper
{
    public class FlightMapper : GeneralMapper<Flight, FlightResponse>
    {
        public override FlightResponse MapperT1T2(Flight input)
        {
            TransportMapper transportMapper = new TransportMapper();

            return new FlightResponse
            {
                Destination = input.Destination,
                Origin = input.Origin,
                Price = input.Price,
                Transports = transportMapper.MapperT1T2(input.Transports)
            };
        }

        public override IEnumerable<FlightResponse> MapperT1T2(IEnumerable<Flight> input)
        {
            foreach (var flight in input)
            {
                yield return MapperT1T2(flight);
            }
        }
    }
}
