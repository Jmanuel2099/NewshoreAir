using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Journey.Entities
{
    /// <summary>
    /// Transport represents the transport attributes of the NewshoreAir model. 
    /// </summary>
    public class Transport
    {
        public int TransportId { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
    }
}
