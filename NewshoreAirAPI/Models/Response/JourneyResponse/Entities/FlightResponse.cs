using NewshoreAirDomain.Journey.Entities;

namespace NewshoreAirAPI.Models.Response.JourneyResponse.Entities
{
    /// <summary>
    /// FlightResponse respects the flight model to give a response to a request.
    /// </summary>
    public class FlightResponse
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public TransportResponse Transports { get; set; }
    }
}
