using NewshoreAirAPI.Models.Response.JourneyResponse.Entities;
using NewshoreAirDomain.Journey.Entities;

namespace NewshoreAirAPI.Models.Response.JourneyResponse
{
    /// <summary>
    /// JourneyResponse respects the journey model to give a response to a request.
    /// </summary>
    public class JourneyResponse
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public IEnumerable<FlightResponse> Flights { get; set; }
    }
}
