using System.ComponentModel.DataAnnotations;

namespace NewshoreAirAPI.Models.Request
{
    /// <summary>
    /// JourneyRequest represents the model of the request received by the api
    /// </summary>
    public class JourneyRequest
    {
		public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
