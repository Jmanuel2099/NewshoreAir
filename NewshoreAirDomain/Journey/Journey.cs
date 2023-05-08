using NewshoreAirDomain.Journey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Journey
{
    /// <summary>
    /// Journey represents the travel attributes of the NewshoreAir model.
    /// </summary>
    public class Journey
    {
        public int JourneyId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public IEnumerable<Flight> Flights { get; set; }
    }
}
