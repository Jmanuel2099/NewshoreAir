using NewshoreAirDomain.Journey.Entities;

namespace NewshoreAirAPI.Models.Response.JourneyResponse.Entities
{
    public class FlightResponse
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public TransportResponse Transports { get; set; }
    }
}
