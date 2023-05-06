using System.ComponentModel.DataAnnotations;

namespace NewshoreAirAPI.Models.Request
{
    public class JourneyRequest
    {
		public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
