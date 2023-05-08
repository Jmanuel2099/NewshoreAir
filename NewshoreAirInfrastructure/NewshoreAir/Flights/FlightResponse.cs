using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.NewshoreAir.Flights
{
    /// <summary>
    /// FlightResponse represents the model that has the response from the NewshoreAir server.
    /// </summary>
    public class FlightResponse
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        public float Price { get; set; }
    }
}
