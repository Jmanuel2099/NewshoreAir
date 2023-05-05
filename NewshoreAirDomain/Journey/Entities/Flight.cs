using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Journey.Entities
{
    public class Flight
    {
        private readonly List<Transport> _transports = new List<Transport>();
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }

        public IReadOnlyList<Transport> Transports => _transports.ToList();

        public Flight(string origin, string destination, float price)
        {
            Origin = origin;
            Destination = destination;
            Price = price;
        }
    }
}
