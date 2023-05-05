using NewshoreAirDomain.Journey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Journey
{
    public class Journey
    {
        private readonly List<Flight> _flights = new List<Flight>();
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }

        public IReadOnlyList<Flight> Flights => _flights.ToList();

        public Journey(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
        }
    }
}
