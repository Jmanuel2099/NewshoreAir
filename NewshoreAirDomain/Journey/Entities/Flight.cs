using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Journey.Entities
{
    public class Flight
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public Transport Transport { get; set; }
    }
}
