using NewshoreAirAPI.Models.Response.JourneyResponse;
using NewshoreAirDomain.Journey;

namespace NewshoreAirAPI.Mapper
{
    public class JourneyMapper : GeneralMapper<Journey, JourneyResponse>
    {
        public override JourneyResponse MapperT1T2(Journey input)
        {
            FlightMapper flightMapper = new FlightMapper(); 

            return new JourneyResponse
            { 
                Origin = input.Origin,
                Destination = input.Destination,
                Price = input.Price,
                Flights = flightMapper.MapperT1T2(input.Flights)
            };
        }

        public override IEnumerable<JourneyResponse> MapperT1T2(IEnumerable<Journey> input)
        {
            foreach (var journey in input)
            {
                yield return MapperT1T2(journey);
            }
        }
    }
}
