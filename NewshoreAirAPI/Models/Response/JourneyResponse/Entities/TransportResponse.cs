namespace NewshoreAirAPI.Models.Response.JourneyResponse.Entities
{
    /// <summary>
    /// TransportResponse respects the transport model to give a response to a request.
    /// </summary>
    public class TransportResponse
    {
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
    }
}
