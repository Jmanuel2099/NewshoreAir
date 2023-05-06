using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirContracts.Journey
{
    public record JourneyRequest(
        string Origin,
        string Destination
     );
}
